using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Abstraction;
using Data.Abstraction;
using Entities;
using Models;

namespace Business.Implementation
{
    public class DishService : IDishService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        private const int closeTime = 23;

        public DishService(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public IEnumerable<DishModel> GetAvailableDishes()
        {
            var dishes = _unit.DishRepository.FindAll().ToList();

            var availableDishes = new List<Dish>();

            foreach (var dish in dishes)
            {
                foreach (var ingredient in dish.Ingredients)
                {
                    if (!ingredient.Ingredient.IsHard && ingredient.Ingredient.Quantity > 0)
                    {
                        availableDishes.Add(dish);
                    }

                    if (ingredient.Ingredient.IsHard && DateTime.Now.Hour < closeTime - 1.5 && ingredient.Ingredient.Quantity > 0)
                    {
                        availableDishes.Add(dish);
                    }
                }
            }

            var dishModels = _mapper.Map<IEnumerable<DishModel>>(availableDishes);

            return dishModels;
        }

        public DateTime OrderDish(DishModel dish)
        {
            var dishEntity = _unit.DishRepository.FindByCondition(d => d.Id == dish.Id).SingleOrDefault();

            var dishIngredients = dishEntity.Ingredients.Select(d => d.Ingredient);

            foreach (var ingredient in dishIngredients)
            {
                ingredient.Quantity -= 1;
            }
            
            _unit.DishRepository.Update(dishEntity);

            return dish.PrepareTime;
        }
    }
}