using RKISControl.ViewModels;
using RKISControl.ViewModels.RKISControl.ViewModels;
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
        private PageViewLocator pageViewLocator;

        public MallPageView(PageViewLocator pageViewLocator)
        {
            InitializeComponent();
            this.pageViewLocator = pageViewLocator;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            pageViewLocator.NavigateService.NavigateToPage(pageViewLocator.ManagerPageMenuView);
        }
    }
}
