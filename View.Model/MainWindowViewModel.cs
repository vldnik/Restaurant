using Business.Abstraction;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace View.Model
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Dish selectedDish;
        private IDishService _dishService;
        private IIngredientService _ingredientService;
        private ObservableCollection<DishModel> _dishModels;

        public ObservableCollection<Dish> Dishes { get; set; }
        public Dish SelectedDish
        {
            get { return selectedDish; }
            set
            {
                selectedDish = value;
                OnPropertyChanged("SelectedDish");
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public MainWindowViewModel( IDishService dishService, IIngredientService ingredientService)
        {
            
            _dishService = dishService;
            _ingredientService = ingredientService;
            
            _dishModels = new ObservableCollection<DishModel>(_dishService.GetAvailableDishes());
        }
    }
}
