using System;
using System.Collections.Generic;

namespace Entities
{
    public class Dish : BaseEntity
    {
        public string Name { get; set; }
        
        public int Weight { get; set; }

        public int PrepareTimeInMinutes { get; set; }

        public ICollection<DishIngredient> Ingredients { get; set; } = new List<DishIngredient>();
    }
}