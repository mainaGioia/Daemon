using FinetunerApp.Helpers;
using FinetunerApp.Models;
using FinetunerApp.Services;
using FinetunerApp.Services.Navigation;
using Xamarin.Forms;

namespace FinetunerApp.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        protected readonly INavigationService NavigationService = new NavigationService();


        /// <summary>
        /// Backing field and public property to set and get the state of the item
        /// </summary>
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetObservableProperty(ref isBusy, value); }
        }


        /// <summary>
        /// Backing field and public property to set and get the title of the item
        /// </summary>
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetObservableProperty(ref title, value); }
        }
    }
}

