using Xamarin.Forms;

namespace XamarinNavy.Views
{
	public partial class BaseMasterDetailPage : MasterDetailPage
	{
		public BaseMasterDetailPage(ContentPage masterPage, NavigationPage detailPage)
		{
			Master = masterPage;
			Detail = detailPage;
			InitializeComponent();
		}
	}
}
