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
using INavigationService = RKISControl.ViewModels.INavigationService;

namespace RKISControl.Views
{
    /// <summary>
    /// Логика взаимодействия для ManagerPageMenuView.xaml
    /// </summary>
    public partial class ManagerPageMenuView : Page
    {
        private readonly Frame frame;

        private readonly ViewModelLocator viewModelLocator;

        private readonly INavigationService navigationService;

        public ManagerPageMenuView(Frame frame, ViewModelLocator viewModelLocator, INavigationService navigationService)
        {
            InitializeComponent();
            this.frame = frame;
            this.viewModelLocator = viewModelLocator;
            this.navigationService = navigationService;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            navigationService.NavigateToPage(new MallPageView(frame, viewModelLocator, navigationService));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            navigationService.NavigateToPage(new LoginPageView(viewModelLocator));
        }
    }
}
