using XamarinNavy.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinNavy.Views.Samples;

using BaseMenuItem = XamarinNavy.Models.BaseMenuItem;

namespace XamarinNavy.ViewModels
{
    public class DrawerViewModel : BaseViewModel
    {
        public DrawerViewModel()
        {
            Title = "Drawer";
            listItems = new List<BaseMenuItem>
            {
				new BaseMenuItem
				{
					TargetType = typeof(BaseLoginPage),
					Title = "Login",
					Icon = "tab_about.png",
				},
                new BaseMenuItem
                {
                    TargetType = typeof(AboutPage),
                    Title = "About",
                    Icon = "tab_about.png",
                },
                new BaseMenuItem
                {
                    TargetType = typeof(ItemsPage),
                    Title = "Items",
                    Icon = "tab_feed.png",
                }
            };
            SelectedMenuItem = listItems[0];
        }


        public List<BaseMenuItem> ListItems
        {
            get { return listItems; }
            set { SetObservableProperty(ref listItems, value); }
        }
        static List<BaseMenuItem> listItems = new List<BaseMenuItem>();

        public BaseMenuItem SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set
            {
                if (value != null)
                {
                    NavigationService.PushView((Page)Activator.CreateInstance(value.TargetType));
                    SetObservableProperty(ref selectedMenuItem, value);
                    //    PageFactory.AddPreviousPageToStack();
                    //    PageFactory.ShowDetailNavigationPage(value);
                }
                //NavigationService.PushDetailView((Page) Activator.CreateInstance(selectedMenuItem.TargetType));
                //SetObservableProperty(ref selectedMenuItem, value);
            }
        }
        BaseMenuItem selectedMenuItem;


    }
}
