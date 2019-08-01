using BarbeariaFirebase.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Essentials;

namespace BarbeariaFirebase.ViewModels
{
    public class ScheduleTabPageViewModel : ViewModelBase
    {
        public ObservableCollection<BarberService> BarberServicesList { get; }
        public IPageDialogService pageDialogService;
        public NetworkAccess current ;

        public ScheduleTabPageViewModel(INavigationService navigationService, IPageDialogService _pageDialogService) : base(navigationService)
        {
            pageDialogService = _pageDialogService; // DI

            Title = "Agendar";
            BarberServicesList = new ObservableCollection<BarberService>();  

            if (current == NetworkAccess.Internet)
            {
                SyncServices();
            }
        }


        async void SyncServices() {

            if (!IsBusy)
            {
                Exception Error = null;
                BarberServicesList.Clear();
                try
                {
                    IsBusy = true;
                    //var Repository = new Repository();
                    //var Items = await Repository.GetServices();
                    //foreach (var Service in Items)
                    //{
                    //    BarberServicesList.Add(Service);
                    //}


                    //ToDo: implementar logica do Firebase
                }
                catch (Exception ex)
                {
                    Error = ex;
                }
                finally
                {
                    IsBusy = false;
                }
                if (Error != null)
                {
                    await pageDialogService.DisplayAlertAsync("Erro", Error.Message, "OK");
                }
            }
            return;
        }

        //public async void Navigate(object serviceTapped)
        //{
        //    if (serviceTapped != null)
        //    {
        //        if (current == NetworkAccess.Internet)
        //        {
        //            if (Settings.IsLoggedIn)  //Todo: usar settings do essentials
        //            {
        //                NavigationParameters navigationParams = new NavigationParameters();
        //                navigationParams.Add("serviceTapped", serviceTapped);
        //                await NavigationService.NavigateAsync("DaysPage", navigationParams, false);
        //            }
        //            else
        //            {
        //                await pageDialogService.DisplayAlertAsync("Faça o Login", "Para realizar o agendamento é preciso estar logado", "OK");
        //            }
        //        }
        //        else
        //        {
        //            await pageDialogService.DisplayAlertAsync("Sem rede", "Não é possível fazer agendamentos sem conexão com a internet", "OK");
        //        }
        //    }
        //}
    }
}

