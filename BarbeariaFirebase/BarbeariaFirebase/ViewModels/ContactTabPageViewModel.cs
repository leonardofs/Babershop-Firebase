using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
namespace BarbeariaFirebase.ViewModels
{
    public class ContactTabPageViewModel : ViewModelBase
    {

        public DelegateCommand CallBarberCommand { get;  set; }
        public DelegateCommand OpenMapCommand { get;  set; }

        public readonly double lat, lng;
        public string location;

        public ContactTabPageViewModel(INavigationService navigationService):base(navigationService)
        {
            location = "Abrir no Mapa";
            Title = "ONDE ESTAMOS";
            lat= -20.170437;
            lng = -44.912665;
            CallBarberCommand = new DelegateCommand(CallBarber);
            OpenMapCommand = new DelegateCommand(async () => await OpenMap());

        }


       public async Task OpenMap()
        {
           try
           {
                await Map.OpenAsync(lat, lng, new MapLaunchOptions
                {
                    Name = "Onde Estamos",
                    NavigationMode = Xamarin.Essentials.NavigationMode.None
                });
            }
            catch (FeatureNotSupportedException FeatEx)
            {
                //recurso não suportado
            }
            catch (Exception Ex1)
            {
                // Não conseguiu abrir o Mapa
            }

        }



       public void CallBarber()
        {
       
            try
            {
                PhoneDialer.Open("37 32222222");
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex2)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex3)
            {
                // Other error has occurred.
            }
        }


    }
}
