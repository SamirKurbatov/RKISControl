using RKISControl.ViewModels;
using RKISControl.ViewModels.RKISControl.ViewModels;
using System.Windows;
using System.Windows.Controls;


namespace RKISControl.Views
{
    /// <summary>
    /// Логика взаимодействия для ManagerPageMenuView.xaml
    /// </summary>
    public partial class ManagerPageMenuView : Page
    {
        private readonly PageViewLocator pageViewLocator;

        public ManagerPageMenuView(PageViewLocator pageViewLocator)
        {
            InitializeComponent();
            this.pageViewLocator = pageViewLocator;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mallPageViewModel = pageViewLocator.MallPageMenuView.DataContext as MallPageViewModel;
            pageViewLocator.NavigateService.NavigateToPage(pageViewLocator.MallPageMenuView, mallPageViewModel);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var loginViewModel = pageViewLocator.LoginPageView.DataContext as LoginViewModel;
            pageViewLocator.NavigateService.NavigateToPage(pageViewLocator.LoginPageView, loginViewModel);
        }
    }
}
