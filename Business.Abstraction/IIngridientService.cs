using Models;

namespace Business.Abstraction
{
    public interface IIngredientService
    {
        void TakeIngredients(DishModel dish);
    }
}