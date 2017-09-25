
using FinetunerApp.ViewModels;
using Xamarin.Forms;

namespace FinetunerApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
