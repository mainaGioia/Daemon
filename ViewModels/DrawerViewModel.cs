﻿using FinetunerApp.Controls.MenuItems;
using FinetunerApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FinetunerApp.ViewModels
{
    public class DrawerViewModel : BaseViewModel
    {
        public DrawerViewModel()
        {
            Title = "Drawer";
            listItems = new List<CustomMenuItem>
            {
                new CustomMenuItem
                {
                    TargetType = typeof(AboutPage),
                    Title = "About",
                    Icon = "tab_about.png",
                },
                new CustomMenuItem
                {
                    TargetType = typeof(ItemsPage),
                    Title = "Items",
                    Icon = "tab_feed.png",
                },
				new CustomMenuItem
				{
					TargetType = typeof(LoginPage),
					Title = "Login",
					Icon = "tab_about.png",
				}
            };
        }


        public List<CustomMenuItem> ListItems
        {
            get { return listItems; }
            set { SetObservableProperty(ref listItems, value); }
        }
        static List<CustomMenuItem> listItems = new List<CustomMenuItem>();

        public CustomMenuItem SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set
            {
                if (value != null)
                {
                    NavigationService.PushDetailView((Page)Activator.CreateInstance(value.TargetType));
                    SetObservableProperty(ref selectedMenuItem, value);
                    //    PageFactory.AddPreviousPageToStack();
                    //    PageFactory.ShowDetailNavigationPage(value);
                }
                //NavigationService.PushDetailView((Page) Activator.CreateInstance(selectedMenuItem.TargetType));
                //SetObservableProperty(ref selectedMenuItem, value);
            }
        }
        CustomMenuItem selectedMenuItem;


    }
}