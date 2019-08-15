using Prism;
using Prism.Ioc;
using BarbeariaFirebase.ViewModels;
using BarbeariaFirebase.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BarbeariaFirebase
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) {



        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            

            /// configuração do Xamarin.HotReload
            #if DEBUG
                        HotReloader.Current.Run(this);
            #endif

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<MyNavigationPage,MyNavigationPageViewModel>();     
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<AboutTabPage, AboutTabPageViewModel>();
            containerRegistry.RegisterForNavigation<ScheduleTabPage, ScheduleTabPageViewModel>();
            containerRegistry.RegisterForNavigation<DaysPage, DaysPageViewModel>();
            containerRegistry.RegisterForNavigation<HoursPage, HoursPageViewModel>();
            containerRegistry.RegisterForNavigation<loginPage, loginPageViewModel>();
        }
    }
}
