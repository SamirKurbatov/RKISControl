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
    /// Логика взаимодействия для ManagerPageMenuView.xaml
    /// </summary>
    public partial class ManagerPageMenuView : Page
    {
        private readonly Frame frame;

        private readonly LoginViewModel loginViewModel;

        private readonly MallPageViewModel mallPageViewViewModel;

        public ManagerPageMenuView(Frame frame, LoginViewModel loginViewModel, MallPageViewModel mallPageViewViewModel )
        {
            InitializeComponent();
            this.frame = frame;
            this.loginViewModel = loginViewModel;
            this.mallPageViewViewModel = mallPageViewViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new MallPageView(frame, loginViewModel, mallPageViewViewModel));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new LoginPageView(loginViewModel));
        }
    }
}
