using GalaSoft.MvvmLight.Views;
using RKISControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using INavigateService = RKISControl.ViewModels.INavigateService;

namespace RKISControl.Views
{
    /// <summary>
    /// Логика взаимодействия для ManagerPageMenuView.xaml
    /// </summary>
    public partial class ManagerPageMenuView : Page
    {
        private readonly Frame frame;

        private readonly MenuViewModel menuViewModel;

        private readonly MallPageViewModel mallPageViewModel;

        private readonly LoginViewModel loginViewModel;

        private readonly INavigateService navigationService;

        public ManagerPageMenuView(Frame frame, MenuViewModel menuViewModel, MallPageViewModel mallPageViewModel, INavigateService navigationService)
        {
            InitializeComponent();
            this.frame = frame;
            this.menuViewModel = menuViewModel;
            this.navigationService = navigationService;
            this.mallPageViewModel = mallPageViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            navigationService.NavigateToPage(new MallPageView(frame, mallPageViewModel, menuViewModel, navigationService));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            navigationService.NavigateToPage(new LoginPageView(loginViewModel));
        }
    }
}
