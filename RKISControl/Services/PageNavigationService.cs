using RKISControl.Data;
using RKISControl.ViewModels.RKISControl.ViewModels;
using RKISControl.Views;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RKISControl.ViewModels
{
    public class PageNavigationService : INavigateService
    {
        private readonly Frame frame;

        public PageNavigationService(Frame frame)
        {
            this.frame = frame;
        }

        public void NavigateToPage<T>(T page) where T : Page
        {
            frame.Navigate(page);
        }
    }
}
