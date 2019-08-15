using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarbeariaFirebase.ViewModels
{
    public class loginPageViewModel : ViewModelBase
    {

        public DelegateCommand LoginCommand { get; set; }

        public DelegateCommand RegisterCommand { get; set; }


        public loginPageViewModel(INavigationService ns) : base(ns)
        {


            LoginCommand = new DelegateCommand(async () => await Login());
            RegisterCommand = new DelegateCommand(async () => await Register());

        }

        private async Task Register() {

            // todo: navegar para pagina de registro

        }

        private async Task Login() {

            //todo fazer login com o Firebase armazenar token do usuario e navegar para proxima pagina. (daysPage?)


        }



    }
}
