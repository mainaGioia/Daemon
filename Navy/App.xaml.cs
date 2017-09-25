using FinetunerApp.Service.Navigation.MenuItems;
using FinetunerApp.Services.Navigation;
using FinetunerApp.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FinetunerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = InitNavigation();
        }



        private Page InitNavigation()
        {
            var navigationService = new NavigationService();
            //return navigationService.InitializeAsync(new LoginView());
            return navigationService.InitializeDrawerAsync(new DrawerPage(), new LoginPage());
            // TabbedPage
            //return navigationService.InitializeTabsAsync(new List<CustomMenuItem> {
            //    new CustomMenuItem { TargetType = typeof(AboutPage), Title = "About", Icon = "tab_about.png" },
            //    new CustomMenuItem { TargetType = typeof(ItemsPage), Title = "Browse", Icon = "tab_feed.png" },
            //});
        }

        /// <summary>
        /// Initialises the navigator 
        /// in future, it will inizialise the gps and check for authentication
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();

            //if (Device.RuntimePlatform != Device.Windows)
            //{
            //    await InitNavigation();
            //}

            //if (Settings.AllowGpsLocation && !Settings.UseFakeLocation)
            //{
            //    await GetGpsLocation();
            //}

            //if (!Settings.UseMocks && !string.IsNullOrEmpty(Settings.AuthAccessToken))
            //{
            //    await SendCurrentLocation();
            //}

            base.OnResume();
        }
    }
}
