using Microsoft.Extensions.DependencyInjection;
using RKISControl.Data;
using RKISControl.Services;
using RKISControl.Views;
using System;
using System.Net.Http.Headers;
using System.Windows.Controls;

namespace RKISControl.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IViewModelFactory viewModelFactory;

        public ViewModelLocator(IServiceProvider provider)
        {
            viewModelFactory = provider.GetRequiredService<ViewModelFactory>();

            MenuViewModel = viewModelFactory.CreateMenuPageViewModel();
            MallPageViewModel = viewModelFactory.CreateMallPageViewModel(UpdateMallPageViewModel, AddMallPageViewModel, MenuViewModel);
            AddMallPageViewModel = viewModelFactory.CreateAddMallPageViewModel(MallPageViewModel, MenuViewModel);
            UpdateMallPageViewModel = viewModelFactory.CreateUpdateMallPageViewModel(MallPageViewModel, MenuViewModel);
            LoginViewModel = viewModelFactory.CreateLoginViewModel(MallPageViewModel, MenuViewModel);
        }

        public LoginViewModel LoginViewModel { get; }

        public MallPageViewModel MallPageViewModel { get; }

        public AddMallPageViewModel AddMallPageViewModel { get; }

        public UpdateMallPageViewModel UpdateMallPageViewModel { get; }

        public MenuViewModel MenuViewModel { get; }
    }
}
