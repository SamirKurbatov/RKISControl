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

        private readonly LoginViewModel loginViewModel;

        public AddMallPageView(Frame frame, MallPageViewModel mallPageViewModel, LoginViewModel loginViewModel = null)
        {
            InitializeComponent();

            this.frame = frame;
            this.mallPageViewModel = mallPageViewModel;
            this.loginViewModel = loginViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new MallPageView(frame, loginViewModel, mallPageViewModel));
        }
    }
}
