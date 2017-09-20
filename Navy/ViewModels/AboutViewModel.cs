using FinetunerApp.Services.Navigation;
using FinetunerApp.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FinetunerApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }

        public ICommand GotoNextCommand { get; }
    }
}
