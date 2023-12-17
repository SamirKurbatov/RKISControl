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
    /// Логика взаимодействия для LoginPageView.xaml
    /// </summary>
    public partial class LoginPageView : Page
    {
        private readonly Frame frame;

        private LoginViewModel loginViewModel;

        private MenuViewModel menuViewModel;

        public LoginPageView(Frame frame, MenuViewModel menuViewModel, LoginViewModel loginViewModel)
        {
            InitializeComponent();
            this.menuViewModel = menuViewModel;
            this.frame = frame;
            this.loginViewModel = loginViewModel;
            DataContext = loginViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var worker = loginViewModel?.Worker;

            if (worker != null && worker.Role == "Администратор")
            {
                menuViewModel.Role = "Администратор";

                frame.Navigate(new MenuPageView(frame)
                {
                    DataContext = menuViewModel
                });
            }
        }
    }
}
