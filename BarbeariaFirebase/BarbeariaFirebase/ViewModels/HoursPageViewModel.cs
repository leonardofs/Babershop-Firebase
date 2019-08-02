using BarbeariaFirebase.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarbeariaFirebase.ViewModels
{
    public class HoursPageViewModel : ViewModelBase
    {
        private INavigationParameters _navigationParams;
        public DelegateCommand<Object> ItemTappedCommand { get; }


        public HoursPageViewModel(INavigationService ns):base(ns)
        {

            ItemTappedCommand = new DelegateCommand<Object>(async (Object obj) => await ItemTapped(obj));

            //todo: preencher listview com horarios disponiveis
        }

        public override void OnNavigatedTo(INavigationParameters navigationParams)
        {   
           // BarberService serviceTapped = navigationParams.GetValue<BarberService>("serviceTapped"); //passa o parametro para proxima navegação
            _navigationParams = navigationParams;//passa o parametro para proxima navegação

            if (navigationParams.GetNavigationMode() == 0)
                navigationService.GoBackAsync(null, false);
        }


       public async Task ItemTapped(Object obj) {

         //   todo: confirmar com o usuario o servico data e horario e gravar no firebase (checar permissoes)

        }



    }
}
