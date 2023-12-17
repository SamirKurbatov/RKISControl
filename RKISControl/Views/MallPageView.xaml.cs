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
    /// Логика взаимодействия для MallPageView.xaml
    /// </summary>
    public partial class MallPageView : Page
    {
        private readonly Frame frame;

        private LoginViewModel viewModel;

        public MallPageView(Frame frame, LoginViewModel viewModel)
        {
            InitializeComponent();
            this.frame = frame;
            this.viewModel = viewModel;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new ManagerPageMenuView(frame, viewModel));
        }
    }
}
