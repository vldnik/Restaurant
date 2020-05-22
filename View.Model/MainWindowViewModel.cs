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

        private RelayCommand _updateWindowCommand;

        public MainWindowViewModel( IDishService dishService, IIngredientService ingredientService)
        {
            
            _dishService = dishService;
            _ingredientService = ingredientService;

            _dishModels = new BindingList<DishModel>(_dishService.GetAvailableDishes().ToList());
           
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
        internal void UpdateWindow()
        {
            DishModels = new BindingList<DishModel>(_dishService.GetAvailableDishes().ToList());
            
        }
        public RelayCommand UpdateWindowCommand
        {
            get
            {
                return _updateWindowCommand ??= new RelayCommand(o =>
                {
                    UpdateWindow();
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
