using Entities;

namespace Data.Abstraction
{
    public interface IUnitOfWork
    {
        public IRepository<Dish> DishRepository { get; }

        public IRepository<Ingredient> IngredientRepository { get; }

        void Save();
    }
}