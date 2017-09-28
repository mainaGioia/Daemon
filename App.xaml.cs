using FinetunerApp.Services.Navigation;
using FinetunerApp.Views;


using Xamarin.Forms;

namespace FinetunerApp
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

			MainPage = InitNavigation();

		}


		Page InitNavigation()
		{
			var navigationService = new NavigationService();
			//return navigationService.InitializeAsync(new LoginPage());
			return navigationService.InitializeDrawerAsync(new DrawerPage(), new LoginPage());
			//return navigationService.InitializeTabsAsync(new List<CustomMenuItem> {
			//    new CustomMenuItem { TargetType = typeof(AboutPage), Title = "About", Icon = "tab_about.png" },
			//    new CustomMenuItem { TargetType = typeof(ItemsPage), Title = "Browse", Icon = "tab_feed.png" },
			//});
		}
    }
}
