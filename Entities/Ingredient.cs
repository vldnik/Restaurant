using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public bool IsHard { get; set; }

        public ICollection<DishIngredient> Dishes { get; set; }
    }
}