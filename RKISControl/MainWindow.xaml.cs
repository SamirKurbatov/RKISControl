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

        private INavigationService pageNavigationService;

        private IServiceProvider serviceProvider;

        public MainWindow()
        {
            InitializeComponent();

            RegisterServices();

            RegisterViewModels();

            serviceProvider = services.BuildServiceProvider();

            pageNavigationService = new PageNavigationService(frame);

            var viewModelLocator = new ViewModelLocator(frame, serviceProvider, pageNavigationService);

            pageNavigationService.NavigateToPage(new LoginPageView(viewModelLocator), viewModelLocator.LoginViewModel);
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

        private void RegisterServices()
        {
            services.AddSingleton<INavigationService, PageNavigationService>();
        }
    }
}
