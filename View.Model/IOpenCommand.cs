using Business.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace View.Model
{
    public interface IOpenCommandDish : ICommand
    {
        IDishService DishService { get; set; }
    }

    public interface IOpenCommandIngredient : ICommand
    {
        IIngredientService IngredientService { get; set; }
    }
}
