using XamarinNavy.Views.Samples;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinNavy.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        
        public LoginViewModel()
        {
            Title = "Login";
        }

        public ICommand MoveToNextCommand => new Command( () =>  NavigationService.PushView(new ItemsPage()));

    }
}
