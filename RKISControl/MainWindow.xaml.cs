using Microsoft.Extensions.DependencyInjection;
using RKISControl.Data;
using RKISControl.ViewModels;
using RKISControl.Views;
using System;
using System.Windows;

namespace RKISControl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IServiceCollection services = new ServiceCollection();

        private IServiceProvider serviceProvider;

        public MainWindow()
        {
            InitializeComponent();

            RegisterViewModels();

            serviceProvider = services.BuildServiceProvider();

            var viewModelLocator = new ViewModelLocator(frame, serviceProvider);

            frame.Navigate(new LoginPageView(viewModelLocator));
        }

        private void RegisterViewModels()
        {
            services.AddSingleton<WorkerViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<MenuViewModel>();
            services.AddSingleton<MallPageViewModel>();
            services.AddSingleton<RentMallDataContext>();
            services.AddSingleton<AddMallPageViewModel>();
        }
    }
}
