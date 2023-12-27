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
            pageViewLocator.NavigateService.NavigateToPage(pageViewLocator.MenuPageView);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            pageViewLocator.NavigateService.NavigateToPage(pageViewLocator.LoginPageView);
        }
    }
}
