using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.ApplicationLayer.Main;
using IS3IncomabWebApi.CrossLayer.Interface;
using IS3IncomabWebApi.DomainLayer.Core;
using IS3IncomabWebApi.DomainLayer.Interface;
using IS3IncomabWebApi.Infraestructure.Data;
using IS3IncomabWebApi.Infraestructure.Interface;
using IS3IncomabWebApi.Infraestructure.Repository;

namespace IS3IncomabWebApi.Modules.Injection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            //Data Base Connection in Sql Serever 
            services.AddSingleton<IConnectionDataBase, ConnectionDataBase>();

            //Entity Domain
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerDomain, CustomerDomain>();
            services.AddScoped<ICustomerDto, CustomerMain>();

            //Cylinder
            services.AddScoped<ICylinderRepository, CylinderRepository>();
            services.AddScoped<ICylinderDomain,CylinderDomain>();
            services.AddScoped<ICylinderDto, CylinderMain>();
            
            //Details
            services.AddScoped<IDetailTicketCylinderRepository, DetailTicketCylinderRepository>();

            //user
            services.AddScoped<IUserIncomabRepository, UserIncomabRepository>();
            services.AddScoped<IUserIncomabDomain, UsersDomain>();
            services.AddScoped<IUserDto, UserMain>();

            //MainFlow
            services.AddScoped<IMainFlowDto, MainFlowDtoMain>();

            //ticket
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketDomain, TicketDomain>();
            services.AddScoped<ITicketDto,TicketMain>();

            //details
            services.AddScoped<IDetailTicketCylinderRepository, DetailTicketCylinderRepository>();
            services.AddScoped<IDetailTicketCylinderDomain, DetailTicketCylinderDomain>();
            services.AddScoped<IDetailTicketCylinderDto, DetailTicketCylinderMain>();

            //Report
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportMain, ReportMain>();

            return services;
        }
    }
}
