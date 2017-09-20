using FinetunerApp.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace FinetunerApp.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        
        public LoginViewModel()
        {
            Title = "Login";
        }

        public ICommand MoveToNextCommand => new Command(async () => await NavigationService.PushView(new AboutPage()));

    }
}
