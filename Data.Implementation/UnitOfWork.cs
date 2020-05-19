using Data.Abstraction;
using Entities;

namespace Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantDbContext _context;

        public UnitOfWork(RestaurantDbContext context, IRepository<Dish> dishRepository, IRepository<Ingredient> ingredientRepository)
        {
            _context = context;
            DishRepository = dishRepository;
            IngredientRepository = ingredientRepository;
        }

        public IRepository<Dish> DishRepository { get; }
        public IRepository<Ingredient> IngredientRepository { get; }
        
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}