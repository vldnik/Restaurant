using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation
{
    public class DishRepository : Repository<Dish>
    {
        public DishRepository(RestaurantDbContext context) : base(context)
        {
        }

        public override IQueryable<Dish> FindAll()
        {
            return _dbSet.Include(x => x.Ingredients).ThenInclude(t => t.Ingredient).AsQueryable();
        }
    }
}