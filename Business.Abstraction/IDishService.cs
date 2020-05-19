using System;
using System.Collections.Generic;
using Models;

namespace Business.Abstraction
{
    public interface IDishService
    {
        IEnumerable<DishModel> GetAvailableDishes();

        DateTime OrderDish(DishModel dish);
    }
}