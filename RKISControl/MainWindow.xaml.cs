using Microsoft.Extensions.DependencyInjection;
using RKISControl.Data;
using RKISControl.Services;
using RKISControl.Services.Factory;
using RKISControl.ViewModels;
using RKISControl.ViewModels.RKISControl.ViewModels;
using RKISControl.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RKISControl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceCollection services = new ServiceCollection();

        private readonly IServiceProvider serviceProvider;

        private readonly PageViewLocator pageViewLocator;

        public MainWindow()
        {
            InitializeComponent();

            RegisterComponents();

            serviceProvider = services.BuildServiceProvider();

            pageViewLocator = serviceProvider.GetRequiredService<PageViewLocator>();

            pageViewLocator.NavigateService.NavigateToPage(pageViewLocator.LoginPageView);
        }

        private void RegisterViewModels()
        {
            services.AddSingleton<WorkerService>();
            services.AddSingleton<MenuViewModel>();
            services.AddSingleton<ManagerMenuViewModel>();
            services.AddSingleton<MallPageViewModel>();
            services.AddSingleton<AddMallPageViewModel>();
            services.AddSingleton<TenantsPageViewModel>();
            services.AddSingleton<UpdateMallPageViewModel>();
            services.AddTransient<LoginViewModel>();
        }

        private void RegisterServices()
        {
            services.AddSingleton<PageViewLocator>();
            services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            services.AddSingleton<IPageViewFactory, PageViewFactory>();
            services.AddSingleton(p => new ViewModelFactory(serviceProvider, frame));
            services.AddSingleton(p => new PageViewFactory());
            services.AddSingleton<RentMallDataContext>();
            services.AddSingleton(provider => new PageNavigationService(frame));
            services.AddSingleton<INavigateService, PageNavigationService>();
        }

        private void RegisterComponents()
        {
            RegisterServices();
            RegisterViewModels();
        }
    }
}
