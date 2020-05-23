using Business.Abstraction;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace View.Model
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IDishService _dishService;
        private readonly IIngredientService _ingredientService;

        private BindingList<DishModel> _dishModels;
        
        private decimal _totalPrice;
        private int _timeToWait;
        private RelayCommand _makeOrderCommand;

        public MainWindowViewModel( IDishService dishService, IIngredientService ingredientService)
        {
            
            _dishService = dishService;
            _ingredientService = ingredientService;

            DishModels = new BindingList<DishModel>(_dishService.GetAvailableDishes().ToList());
           
        }

        public decimal TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChanged();
            }
        }

        public int TimeToWait 
        { 
            get => _timeToWait;
            set
            {
                _timeToWait = value;
                OnPropertyChanged();
            }
        }
        
        public BindingList<DishModel> DishModels
        {
            get => _dishModels;
            set
            {
                _dishModels = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand MakeOrderCommand  => _makeOrderCommand ??= new RelayCommand(o =>
        {
            makeOrder();
        }, o => checkSelection());

        private void makeOrder()
        {
            var selected = DishModels.Where(x => x.IsSelected);
            _dishService.MakeOrder(selected, out decimal totalPrice, out int timeToWait);
            TotalPrice = totalPrice;
            TimeToWait = timeToWait;
        }
        
        private bool checkSelection()
        {
            var flag = DishModels.Any(x => x.IsSelected == true);
            return flag;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
