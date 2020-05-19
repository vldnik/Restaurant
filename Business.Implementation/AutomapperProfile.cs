using System.Linq;
using AutoMapper;
using Entities;
using Models;

namespace Business.Implementation
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Dish, DishModel>()
                .ForMember(d => d.Ingredients, 
                    opt => opt.MapFrom(d => d.Ingredients.Select(i => i.Ingredient)))
                .ReverseMap()
                .ForMember(d => d.Ingredients, opt => opt.MapFrom(d => d.Ingredients.Select(ingredient => new DishIngredient{IngredientId = ingredient.Id })));
            
            CreateMap<Ingredient, IngredientModel>()
                .ForMember(d => d.Dishes, 
                    opt => opt.MapFrom(d => d.Dishes.Select(d => d.Dish)))
                .ReverseMap()
                .ForMember(i => i.Dishes, opt => opt.MapFrom(i => i.Dishes.Select(dishes => new DishIngredient{DishId = dishes.Id })));
        }
    }
}