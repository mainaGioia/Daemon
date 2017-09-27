using FinetunerApp.ViewModels;
using Xamarin.Forms;

namespace FinetunerApp.Views
{
    public partial class BaseMasterDetailPage : Xamarin.Forms.MasterDetailPage
    {
        public BaseMasterDetailPage(ContentPage masterPage, NavigationPage detailPage)
        {
            Master = masterPage;
            Detail = detailPage;
            InitializeComponent();
        }
    }
}
