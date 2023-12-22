using RKISControl.ViewModels;
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

        private readonly ViewModelLocator viewModelLocator;

        private readonly INavigationService navigationService;

        public MallPageView(Frame frame, ViewModelLocator viewModelLocator, INavigationService navigationService)
        {
            InitializeComponent();
            this.frame = frame;
            this.viewModelLocator = viewModelLocator;
            this.navigationService = navigationService;

            DataContext = viewModelLocator.MallPageViewModel;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            navigationService.NavigateToPage(new ManagerPageMenuView(frame, viewModelLocator, navigationService), viewModelLocator.MenuViewModel);
        }
    }
}
