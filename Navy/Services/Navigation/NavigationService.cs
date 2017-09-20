using System;
using System.Threading.Tasks;
using FinetunerApp.ViewModels;
using Xamarin.Forms;
using System.Globalization;
using System.Reflection;
using FinetunerApp.Views;
using System.Collections.Generic;
using FinetunerApp.Service.Navigation.MenuItems;

namespace FinetunerApp.Services.Navigation
{
    /// <summary>
    /// Implements the INavigationService providing view navigation.
    /// </summary>
    public class NavigationService : INavigationService
    {

        /// <summary>
        /// Implements the singleton pattern. There must be one single instance of the navigatorservice.
        /// </summary>
        public static NavigationService Instance
        {
            get { if (instance == null) instance = new NavigationService(); return instance; }
        }
        static NavigationService instance;


        public NavigationService() { }

      
        /// <summary>
        /// Implements the corresponding property of the INavigationService interface.
        /// Gets the previous page in the navigation stack
        /// </summary>
        public BaseViewModel PreviousPageViewModel
        {
            get
            {
                var mainPage = Application.Current.MainPage as BaseNavigationPage;
                var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
                return viewModel as BaseViewModel;
            }
        }


        /// <summary>
        /// Initialises the masterdetailpage.
        /// </summary>
        /// <param name="Master"> Masterpage, alias the list of menuitems </param>
        /// <param name="Detail"> Detailpage, alias the first page to display in the navigation part </param>
        /// <returns></returns>
        public Page InitializeDrawerAsync(ContentPage masterPage, ContentPage detailPage)
        {
            return new Views.MasterDetailPage(masterPage, new BaseNavigationPage(detailPage));
        }


        public Page InitializeTabsAsync(List<CustomMenuItem> tabs)
        {
            TabbedPage tabNavigator = new TabbedPage();
            foreach (CustomMenuItem item in tabs)
                tabNavigator.Children.Add(
                    new BaseNavigationPage((Page)Activator.CreateInstance(item.TargetType)) { Icon = item.Icon, Title = item.Title }
                    );
            return tabNavigator;
        }

        /// <summary>
        /// Implements the corresponding method in the INavigationService interface.
        /// OnStart, performs navigation to the first page to be displayed in the app.
        /// </summary>
        /// <returns></returns>
        public Page InitializeAsync(Page page)
        {
            //if (string.IsNullOrEmpty(Settings.AuthAccessToken))
            return new BaseNavigationPage(page);

            //else
            //    return NavigateToAsync<MainViewModel>();
        }


        /// <summary>
        /// Implements the corresponding method in the INavigationService interface.
        /// </summary>
        /// <param name="page"> page to navigate to </param>
        /// <param name="transArgs"> isModal and isAnimated </param>
        /// <param name="args"> optional paraters for the page </param>
        /// <returns></returns>
        public async Task PushView(Page page, ViewTransitionArgs transArgs, object args = null)
        {
            var mainPage = Application.Current.MainPage as BaseNavigationPage;
            if (transArgs == null)
                transArgs = new ViewTransitionArgs();

            if (mainPage != null)
            {
                var numPages = mainPage.Navigation.NavigationStack.Count;
                var currentPage = (numPages > 1) ? mainPage.Navigation.NavigationStack[numPages - 1] : mainPage;

                System.Diagnostics.Debug.WriteLine("number of pages in navigationstack for currentpage: " + currentPage.Navigation.NavigationStack.Count);
                System.Diagnostics.Debug.WriteLine("number of pages in navigationstack for mainpage: " + mainPage.Navigation.NavigationStack.Count);

                if (transArgs.IsModal)
                    await currentPage.Navigation.PushModalAsync(page, transArgs.IsAnimated);
                else
                    await currentPage.Navigation.PushAsync(page, transArgs.IsAnimated);
            }
            else
                Application.Current.MainPage = new BaseNavigationPage(page);
        }


        /// <summary>
        /// Implements the corresponding method in the INavigationService interface.
        /// Opens the specified page and closes the drawer (isPresented = false)
        /// </summary>
        /// <param name="page"> page to be opened as DetailPage </param>
        /// <param name="args"> optional arguments for the page to be opened </param>
        public void PushDetailView(Page page, object args = null)
        {
            var mainPage = Application.Current.MainPage as Xamarin.Forms.MasterDetailPage;
            if (mainPage != null)
            {
                mainPage.Detail = new BaseNavigationPage(page);
                mainPage.IsPresented = false;
            }
        }


        /// <summary>
        /// Implements the corresponding method in the INavigationService interface.
        /// Removes the current page from the stack.
        /// </summary>
        /// <param name="transArgs"> to specify if the page is modal </param>
        public void PopView(ViewTransitionArgs transArgs)
        {
            var mainPage = Application.Current.MainPage as BaseNavigationPage;
            System.Diagnostics.Debug.WriteLine("before pop: #pages in navigationstack: " + mainPage.Navigation.NavigationStack.Count);
            System.Diagnostics.Debug.WriteLine("before pop: #pages in modalstack: " + mainPage.Navigation.NavigationStack.Count);

            if (transArgs.IsModal)
                mainPage.Navigation.RemovePage(mainPage.Navigation.ModalStack[mainPage.Navigation.ModalStack.Count - 1]);
            else
                mainPage.Navigation.RemovePage(mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 1]);
        }

        /// <summary>
        /// Implements the corresponding method in the INavigationService interface.
        /// Removes the last page before the current one in the stack.
        /// </summary>
        /// <returns></returns>
        public Task RemoveLastFromBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as BaseNavigationPage;

            if (mainPage != null)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }


        /// <summary>
        /// Implements the corresponding method in the INavigationService interface.
        /// Clears all the navigation stack removing all the pages.
        /// </summary>
        /// <returns></returns>
        public Task RemoveBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as BaseNavigationPage;

            if (mainPage != null)
            {
                for (int i = 0; i < mainPage.Navigation.NavigationStack.Count - 1; i++)
                {
                    var page = mainPage.Navigation.NavigationStack[i];
                    mainPage.Navigation.RemovePage(page);
                }
            }

            return Task.FromResult(true);
        }

        
        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }
    }
}
