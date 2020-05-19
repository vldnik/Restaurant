using System.Collections.Generic;

namespace Models
{
    public class IngredientModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Quantity { get; set; }

        public bool IsHard { get; set; }

        public ICollection<DishModel> Dishes { get; set; }
    }
}