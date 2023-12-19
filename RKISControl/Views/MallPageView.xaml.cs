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

        private readonly LoginViewModel viewModel;

        private readonly MallPageViewModel mallPageViewModel;

        public MallPageView(Frame frame, LoginViewModel viewModel, MallPageViewModel mallPageViewModel)
        {
            InitializeComponent();
            this.frame = frame;
            this.viewModel = viewModel;
            this.mallPageViewModel = mallPageViewModel;

            DataContext = this.mallPageViewModel;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new ManagerPageMenuView(frame, viewModel, mallPageViewModel));
        }
    }
}
