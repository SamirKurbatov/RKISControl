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

        public ManagerPageMenuView(Frame frame)
        {
            this.frame = frame;
        }

        public ManagerPageMenuView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new MallPageView(frame));
        }
    }
}
