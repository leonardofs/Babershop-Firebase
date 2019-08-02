using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BarbeariaFirebase.Models;
using System.Threading.Tasks;

namespace BarbeariaFirebase.ViewModels
{
    public class DaysPageViewModel : ViewModelBase
    {
        public ObservableCollection<DateTime> Dates { get; }
        private INavigationParameters _navigationParams;
        public DelegateCommand<DateTime> ItemTappedCommand { get; set; }

        public DaysPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "ESCOLHA O DIA";
            Dates = new ObservableCollection<DateTime>();
            FillDaysCollection();

            ItemTappedCommand = new DelegateCommand<DateTime>(async (DateTime date) => await ItemTapped(date));

        }

        private void FillDaysCollection()
        {
            for (int i = 0; i < 15; i++)
            {
                DateTime date = DateTime.Today.AddDays(i);

                if (date.DayOfWeek == 0 || date.DayOfWeek == DayOfWeek.Saturday)
                    continue;
                else
                    Dates.Add(date);
            }
        }


        public override void OnNavigatedTo(INavigationParameters navigationParams)
        {
            BarberService serviceTapped = navigationParams.GetValue<BarberService>("serviceTapped"); //passa o parametro para proxima navegação
            _navigationParams = navigationParams;

            if (navigationParams.GetNavigationMode() == 0)
                navigationService.GoBackAsync(null, false);
        }


        public async Task ItemTapped(DateTime dayTapped)
        {

            if (dayTapped != null)
            {

                _navigationParams.Add("dayTapped", dayTapped);
                await navigationService.NavigateAsync("HoursPage", _navigationParams, false);

            }
            else
            {
                // todo: usar toast, verificar conexao e login
                //await pageDialogService.DisplayAlertAsync("Sem rede", "Não é possível fazer agendamentos sem conexão com a internet", "OK");
            }
        }





  

    }

}
