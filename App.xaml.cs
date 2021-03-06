﻿using XamarinNavy.Services.Navigation;
using XamarinNavy.Views;


using Xamarin.Forms;

namespace XamarinNavy
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

            //sets the mainpage (mandatory) and the main navigation 
            InitNavigation();

		}


		void InitNavigation()
		{
			var navigationService = new NavigationService();
			//return navigationService.InitializeAsync(new BaseLoginPage());
            navigationService.InitializeDrawerAsync(new BaseDrawerPage(), new ContentPage());
			//return navigationService.InitializeTabsAsync(new List<CustomMenuItem> {
			//    new CustomMenuItem { TargetType = typeof(AboutPage), Title = "About", Icon = "tab_about.png" },
			//    new CustomMenuItem { TargetType = typeof(ItemsPage), Title = "Browse", Icon = "tab_feed.png" },
			//});
		}
	}
}
