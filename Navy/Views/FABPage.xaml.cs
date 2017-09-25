
using FinetunerApp.ViewModels;
using Xamarin.Forms;

namespace FinetunerApp.Views
{
    public partial class FABPage : ContentPage
    {
        public FABPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
