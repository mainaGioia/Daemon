using FinetunerApp.ViewModels;
using Xamarin.Forms;

namespace FinetunerApp.Views
{
    public partial class MasterDetailPage : Xamarin.Forms.MasterDetailPage
    {
        public MasterDetailPage(ContentPage masterPage, NavigationPage detailPage)
        {
            Master = masterPage;
            Detail = detailPage;
            InitializeComponent();
        }
    }
}
