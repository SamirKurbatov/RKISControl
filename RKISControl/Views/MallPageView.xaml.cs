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

        private readonly INavigateService navigationService;

        public MallPageView(Frame frame, INavigateService navigationService, ViewModelLocator viewModelLocator)
        {
            InitializeComponent();
            this.frame = frame;
            this.navigationService = navigationService;
            this.viewModelLocator = viewModelLocator;
            DataContext = this.viewModelLocator.MallPageViewModel;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            var managerPageMenuView = new ManagerPageMenuView(frame,navigationService, viewModelLocator);
            navigationService.NavigateToPage(managerPageMenuView);
        }
    }
}
