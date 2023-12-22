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
    /// Логика взаимодействия для TenantsPageView.xaml
    /// </summary>
    public partial class TenantsPageView : Page
    {
        private readonly Frame frame;

        private readonly ViewModelLocator viewModelLocator;

        private readonly INavigationService navigationService;

        public TenantsPageView(Frame frame, ViewModelLocator viewModelLocator)
        {
            InitializeComponent();
            
            this.frame = frame;

            this.viewModelLocator = viewModelLocator;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            navigationService.NavigateToPage(new MenuPageView(frame, viewModelLocator, navigationService));
        }
    }
}
