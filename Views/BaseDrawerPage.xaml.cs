using XamarinNavy.ViewModels;
using Xamarin.Forms;

namespace XamarinNavy.Views
{
	public partial class BaseDrawerPage : ContentPage
	{
		public BaseDrawerPage()
		{
			InitializeComponent();
			BindingContext = new DrawerViewModel();
		}
	}
}
