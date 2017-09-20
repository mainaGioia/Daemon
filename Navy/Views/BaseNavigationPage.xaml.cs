
using FinetunerApp.ViewModels;
using Xamarin.Forms;

namespace FinetunerApp.Views
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
