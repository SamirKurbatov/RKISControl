using RKISControl.Data;
using RKISControl.ViewModels;
using RKISControl.ViewModels.RKISControl.ViewModels;
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
    /// Логика взаимодействия для LoginPageView.xaml
    /// </summary>
    public partial class LoginPageView : Page
    {
        private readonly PageViewLocator pageViewLocator;

        public LoginPageView(PageViewLocator pageViewLocator)
        {
            InitializeComponent();

            this.pageViewLocator = pageViewLocator;
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var typeOfPageViewModel = pageViewLocator.LoginPageView.DataContext as LoginViewModel;
            var passwordBox = sender as PasswordBox;

            if (passwordBox != null)
            {
                string newPassword = passwordBox.Password;
                typeOfPageViewModel.Password = newPassword;
            }
        }
    }
}
