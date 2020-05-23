using System;
using System.Collections.Generic;

namespace Models
{
    public class DishModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Weight { get; set; }

        public int PrepareTimeInMinutes { get; set; }

        public ICollection<IngredientModel> Ingredients { get; set; } = new List<IngredientModel>();
    }
}