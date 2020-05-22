using AutoMapper;
using Business.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Implementation
{
    public static class BusinessServices
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IDishService, DishService>();

            //чтобы такое написать, нужно создать IngredientService :D
            //services.AddTransient<IIngredientService, IngredientService>();

            var mapperConfig = new MapperConfiguration(c => c.AddProfile(new AutomapperProfile()));

            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}