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

namespace RKISControl.Views
{
    /// <summary>
    /// Логика взаимодействия для AddMallPageView.xaml
    /// </summary>
    public partial class AddMallPageView : Page
    {
        private readonly Frame frame;

        private readonly MallPageViewModel mallPageViewModel;

        private readonly MenuViewModel menuPageViewModel;

        private readonly INavigationService navigationService;

        public AddMallPageView(Frame frame, INavigationService navigationService, MallPageViewModel mallPageViewModel, MenuViewModel menuPageViewModel)
        {
            InitializeComponent();

            this.frame = frame;
            this.navigationService = navigationService;
            this.mallPageViewModel = mallPageViewModel;
            this.menuPageViewModel = menuPageViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            navigationService.NavigateToPage(new MallPageView(frame, mallPageViewModel, menuPageViewModel, navigationService), mallPageViewModel);
        }
    }
}
