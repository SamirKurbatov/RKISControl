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
            var db = provider.GetRequiredService<RentMallDataContext>();
            
            WorkerService = new WorkerService(db);

            MenuViewModel = viewModelFactory.CreateMenuPageViewModel();
            MallPageViewModel = viewModelFactory.CreateMallPageViewModel(this);
            AddMallPageViewModel = viewModelFactory.CreateAddMallPageViewModel(this);
            UpdateMallPageViewModel = viewModelFactory.CreateUpdateMallPageViewModel(this);
            LoginViewModel = viewModelFactory.CreateLoginViewModel(this);
        }

        public LoginViewModel LoginViewModel { get; }

        public MallPageViewModel MallPageViewModel { get; }

        public AddMallPageViewModel AddMallPageViewModel { get; }

        public UpdateMallPageViewModel UpdateMallPageViewModel { get; }

        public MenuViewModel MenuViewModel { get; }

        public WorkerService WorkerService { get; }
    }
}
