using RKISControl.Data;
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
    /// Логика взаимодействия для MenuPageView.xaml
    /// </summary>
    public partial class MenuPageView : Page
    {
        private readonly Frame frame;

        private readonly LoginViewModel loginViewModel;

        public MenuPageView(Frame frame, LoginViewModel loginViewModel)
        {
            InitializeComponent();
            this.frame = frame;
            this.loginViewModel = loginViewModel;
        }

        private void OpenMallWindow_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new TenantsPageView(frame));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new LoginPageView(loginViewModel));
        }
    }
}
