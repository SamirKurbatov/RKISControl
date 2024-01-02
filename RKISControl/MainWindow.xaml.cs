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
using System.Windows.Navigation;

namespace RKISControl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceCollection services = new ServiceCollection();

        private readonly IServiceProvider serviceProvider;

        private readonly IViewModelFactory viewModelFactory;

        private readonly INavigateService navigateService;

        private readonly IPageViewFactory pageViewFactory;

        private readonly PageViewLocator pageViewLocator;

        public MainWindow()
        {
            InitializeComponent();

            RegisterComponents();

            serviceProvider = services.BuildServiceProvider();

            viewModelFactory = serviceProvider.GetRequiredService<ViewModelFactory>();

            navigateService = serviceProvider.GetRequiredService<PageNavigationService>();

            pageViewFactory = serviceProvider.GetRequiredService<PageViewFactory>();

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
            services.AddSingleton<UpdateMallPageViewModel>();
            services.AddSingleton<UpdateTenantsViewModel>();
            services.AddSingleton<AddTenantsViewModel>();
            services.AddSingleton<TenantsViewModel>();
            services.AddTransient<LoginViewModel>();
        }

        private void RegisterServices()
        {
            services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            services.AddSingleton<IPageViewFactory, PageViewFactory>();
            services.AddSingleton(p => new PageViewLocator(pageViewFactory, viewModelFactory, navigateService));
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
