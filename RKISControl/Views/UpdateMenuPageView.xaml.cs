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
    /// Логика взаимодействия для UpdateMenuPageView.xaml
    /// </summary>
    public partial class UpdateMenuPageView : Page
    {
        private readonly Frame frame;

        private readonly ViewModelLocator viewModelLocator;

        private readonly INavigateService navigationService;

        public UpdateMenuPageView(Frame frame, INavigateService navigationService, ViewModelLocator viewModelLocator)
        {
            InitializeComponent();

            this.frame = frame;
            this.navigationService = navigationService;
            this.viewModelLocator = viewModelLocator;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            navigationService.NavigateToPage(new MallPageView(frame, navigationService, viewModelLocator), viewModelLocator.MallPageViewModel);
        }
    }
}
