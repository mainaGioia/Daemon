using FinetunerApp.ViewModels;
using Xamarin.Forms;

namespace FinetunerApp.Views
{
	public partial class DrawerPage : ContentPage
	{
		public DrawerPage()
		{
			InitializeComponent();
			BindingContext = new DrawerViewModel();
		}
	}
}
