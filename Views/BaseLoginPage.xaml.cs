using XamarinNavy.ViewModels;
using Xamarin.Forms;

namespace XamarinNavy.Views
{
	public partial class BaseLoginPage : ContentPage
	{
		public BaseLoginPage()
		{
			InitializeComponent();
			BindingContext = new LoginViewModel();
		}
	}
}
