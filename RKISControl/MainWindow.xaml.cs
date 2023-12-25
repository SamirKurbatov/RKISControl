﻿using Microsoft.Extensions.DependencyInjection;
using RKISControl.Data;
using RKISControl.Services;
using RKISControl.ViewModels;
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

        private readonly INavigateService pageNavigationService;

        private readonly ViewModelLocator viewModelLocator;

        public MainWindow()
        {
            InitializeComponent();

            RegisterComponents();

            serviceProvider = services.BuildServiceProvider();

            pageNavigationService = serviceProvider.GetRequiredService<PageNavigationService>();

            viewModelLocator = new ViewModelLocator(serviceProvider);

            pageNavigationService.NavigateToPage(new LoginPageView(viewModelLocator.LoginViewModel), viewModelLocator.LoginViewModel);
        }

        private void RegisterViewModels()
        {
            services.AddSingleton<WorkerService>();
            services.AddSingleton<MenuViewModel>();
            services.AddSingleton<MallPageViewModel>();
            services.AddSingleton<AddMallPageViewModel>();
            services.AddSingleton<UpdateMallPageViewModel>();
            services.AddTransient<LoginViewModel>();
        }

        private void RegisterServices()
        {
            services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            services.AddSingleton(p => new ViewModelFactory(serviceProvider, frame));
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
