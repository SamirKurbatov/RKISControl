using RKISControl.Data;
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

        public void NavigateToPage(Page view, BaseViewModel viewModel)
        {
            view.DataContext = viewModel;
            frame.Navigate(view);
        }

        public void NavigateToPage(Page view, MenuViewModel menuViewModel = null)
        {
            view.DataContext = menuViewModel;
            frame.Navigate(view);
        }

    }
}
