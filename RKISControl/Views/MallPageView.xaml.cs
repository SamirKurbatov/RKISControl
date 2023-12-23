﻿using RKISControl.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace RKISControl.Views
{
    /// <summary>
    /// Логика взаимодействия для MallPageView.xaml
    /// </summary>
    public partial class MallPageView : Page
    {
        private readonly Frame frame;

        private readonly MallPageViewModel mallPageViewModel;

        private readonly MenuViewModel menuViewModel;

        private readonly INavigateService navigationService;

        public MallPageView(Frame frame, MallPageViewModel mallPageViewModel, MenuViewModel menuViewModel, INavigateService navigationService)
        {
            InitializeComponent();
            this.frame = frame;
            this.mallPageViewModel = mallPageViewModel;
            this.menuViewModel = menuViewModel;
            this.navigationService = navigationService;

            DataContext = mallPageViewModel;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            navigationService.NavigateToPage(new ManagerPageMenuView(frame, menuViewModel, mallPageViewModel, navigationService)
            {
                DataContext = menuViewModel
            });
        }
    }
}
