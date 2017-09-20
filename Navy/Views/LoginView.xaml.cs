
using FinetunerApp.ViewModels;
using Xamarin.Forms;

namespace FinetunerApp.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
