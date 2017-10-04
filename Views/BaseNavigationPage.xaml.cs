using XamarinNavy.ViewModels;
using Xamarin.Forms;

namespace XamarinNavy.Views
{
	public partial class BaseNavigationPage : NavigationPage
	{
		public BaseNavigationPage() : base()
		{
			InitializeComponent();
		}

		public BaseNavigationPage(Page root) : base(root)
		{
			InitializeComponent();
		}

	}
}
