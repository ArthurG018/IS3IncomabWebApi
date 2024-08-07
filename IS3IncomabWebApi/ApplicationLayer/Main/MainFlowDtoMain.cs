using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.StaticClass.Record;

namespace IS3IncomabWebApi.ApplicationLayer.Main
{
    public class MainFlowDtoMain : IMainFlowDto
    {
        private readonly ITicketDto _ticketDto;
        private readonly IDetailTicketCylinderDto _detailTicketCylinderDto;
        private readonly ICylinderDto _cylinderDto;

        public MainFlowDtoMain(ITicketDto ticketDto, IDetailTicketCylinderDto detailTicketCylinderDto, ICylinderDto cylinderDto)
        {
            _ticketDto = ticketDto;
            _detailTicketCylinderDto = detailTicketCylinderDto;
            _cylinderDto = cylinderDto;
        }

        public Response<List<string>> ActionGeneral(SourceMainDTO sourceMainDTO, IEnumerable<CylinderDto> actionListDTOsDG, IEnumerable<CylinderDto> actionListDTOsSale, IEnumerable<CylinderDto> actionListDTOsWarranty)
        {
            var response = new Response<List<string>>();

            try
            {
                if (sourceMainDTO?.Ticket?.Id != 0)
                {
                    response.Message = "No es posible el registro";
                    response.IsSuccess = false;
                    return response;
                }

                if(actionListDTOsDG.Count() == 0 && actionListDTOsSale.Count() == 0 && actionListDTOsWarranty.Count() == 0)
                {
                    response.Message = "Las listas se encuentran vacías";
                    response.IsSuccess = false;
                    return response;
                }
                //var responseTicket = _ticketDto.GetCustomerId(sourceMainDTO.Ticket.CustomerId);

                var ticketCreateOrUpdate = _ticketDto.InsertOrUpdtae(new TicketDto(){
                    Id=0,
                    NumberOfPart=sourceMainDTO.Ticket.NumberOfPart,
                    CustomerId = sourceMainDTO.Ticket.CustomerId,
                    CreateBy = sourceMainDTO.Ticket.CreateBy,
                });

                if (!ticketCreateOrUpdate.IsSuccess)
                {
                    response.Message = ticketCreateOrUpdate.Message;
                    response.IsSuccess = true;
                    return response;
                }

                if (actionListDTOsDG.Count()>0 && actionListDTOsDG.ElementAt(0).Id != -1)
                {
                    foreach (var item in actionListDTOsDG)
                    {
                        var responseDetailTicketCylinder= _detailTicketCylinderDto.Insert(new DetailTicketCylinderDto { IsReturned = 0, IsWarranty = 1, Amount = 0, CylinderId = item.Id, TicketId = ticketCreateOrUpdate.Data });
                        if (responseDetailTicketCylinder.IsSuccess)
                        {
                            if (item.Status.Id == Status.Cliente.Id)
                            {
                                var cylinder = _cylinderDto.GetId(item.Id);
                                if (cylinder.Data != null)
                                {
                                    _cylinderDto.Update(cylinder.Data);
                                }
                            }
                        }
                    }
                    response.IsSuccess = true;
                    //for
                }

                if (actionListDTOsWarranty.Count()>0 && actionListDTOsWarranty.ElementAt(0).Id != -1)
                {
                    foreach (var item in actionListDTOsWarranty)
                    {
                        if (item.Id == 0 && item != null)
                        {
                            if (!_cylinderDto.ValidNumberCylinder(item.Number))
                            {

                                response.Data.Add("El número de cilindro " + item.Number + " ya existe");
                                response.IsSuccess = false;
                                response.Message = "El número de cilindro " + item.Number + " ya existe";
                            }
                            else
                            {
                                item.Status = Status.Garantia;
                                //mapear todos los campos del cilindro
                                var cylinderInsert = _cylinderDto.Insert(item);
                                if (cylinderInsert.IsSuccess)
                                {
                                    _detailTicketCylinderDto.Insert(new DetailTicketCylinderDto
                                    {
                                        IsReturned = 0,
                                        IsWarranty = 1,
                                        CylinderId = cylinderInsert.Data,
                                        TicketId = ticketCreateOrUpdate.Data,

                                    });
                                }
                            
                            }
                            
                        }
                        else
                        {
                            item.Status = Status.Garantia;
                            _cylinderDto.Update(item);
                            _detailTicketCylinderDto.Insert(new DetailTicketCylinderDto
                            {
                                IsWarranty= 1,
                                IsReturned= 0,
                                CylinderId=item.Id,
                                TicketId=ticketCreateOrUpdate.Data,
                            });
                            if (item.Status.Id == Status.Devuelto.Id)
                            {
                                var cylinderGetId = _cylinderDto.GetId(item.Id);
                                _cylinderDto.Update(new CylinderDto
                                {
                                    Id=cylinderGetId.Data.Id,
                                    Number = cylinderGetId.Data.Number,
                                    Status = Status.Disponible,
                                    TypeCylinder = cylinderGetId.Data.TypeCylinder,
                                    IsActive = cylinderGetId.Data.IsActive,
                                });
                            }
                        }
                    }
                    //for
                    response.IsSuccess = true;
                }

                //mapear este error 
                if (actionListDTOsSale.Count()>0 && actionListDTOsSale.ElementAt(0).Id != -1)
                {
                    //for
                    foreach (var item in actionListDTOsSale)
                    {
                        _detailTicketCylinderDto.Insert(new DetailTicketCylinderDto
                        {
                            IsWarranty = 0,
                            IsReturned= 0,
                            CylinderId = item.Id,
                            TicketId = ticketCreateOrUpdate.Data
                        });
                        var cylinderInsertSale = _cylinderDto.GetId(item.Id);
                        _cylinderDto.Update(new CylinderDto
                        {
                            Id = item.Id,
                            Number = cylinderInsertSale.Data.Number,
                            Status = (cylinderInsertSale.Data.Status == Status.Devuelto || cylinderInsertSale.Data.Status == Status.Garantia)?Status.Devuelto:Status.Cliente,
                            TypeCylinder = cylinderInsertSale.Data.TypeCylinder,
                            IsActive = cylinderInsertSale.Data.IsActive
                        });
                    }
                    response.IsSuccess = true;
                }

                if (response.IsSuccess)
                {
                    response.Message = "Consulta Exitosa";
                }
                else
                {
                    response.Message = "Consulta no exitosa, no se encontró listas";
                }
                

            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }
            return response;
        }
        
    }
   
}
