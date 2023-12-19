using RKISControl.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace RKISControl.Views
{
    /// <summary>
    /// Логика взаимодействия для MallPageView.xaml
    /// </summary>
    public partial class MallPageView : Page
    {
        private readonly Frame frame;

        private readonly ViewModelLocator viewModelLocator;

        public MallPageView(Frame frame, ViewModelLocator viewModelLocator)
        {
            InitializeComponent();
            this.frame = frame;
            this.viewModelLocator = viewModelLocator;

            DataContext = viewModelLocator.MallPageViewModel;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new ManagerPageMenuView(frame, viewModelLocator));
        }
    }
}
