using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BarbeariaFirebase.ViewModels
{
    public class MyNavigationPageViewModel : ViewModelBase
    {

        public MyNavigationPageViewModel(INavigationService ns):base(ns)
        {
            Title = "Haircuts Shaves BarberShop";
        }
    }
}
