using IS3IncomabWebApi.CrossLayer.Mapper;

namespace IS3IncomabWebApi.Modules.Mapper
{
    public static class MapperExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(x=>x.AddProfile(new MappingProfile()));
            return services;
        }
    }
}
