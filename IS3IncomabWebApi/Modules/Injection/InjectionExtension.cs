using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.ApplicationLayer.Main;
using IS3IncomabWebApi.CrossLayer.Interface;
using IS3IncomabWebApi.DomainLayer.Core;
using IS3IncomabWebApi.DomainLayer.Interface;
using IS3IncomabWebApi.Infraestructure.Data;
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
            
            services.AddScoped<IDetailTicketCylinderRepository, DetailTicketCylinderRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IUserIncomabRepository, UserIncomabRepository>();

            //users
            services.AddScoped<IUserIncomabRepository, UserIncomabRepository>();


            return services;
        }
    }
}
