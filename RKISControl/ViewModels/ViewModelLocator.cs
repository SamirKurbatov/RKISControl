using Microsoft.Extensions.DependencyInjection;
using RKISControl.Data;
using RKISControl.Views;
using System;
using System.Net.Http.Headers;
using System.Windows.Controls;

namespace RKISControl.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator(IServiceProvider provider, Frame frame)
        {
            MenuViewModel = new MenuViewModel();
            MallPageViewModel = CreateMallPageViewModel(provider, frame);
            AddMallPageViewModel = CreateAddMallPageViewModel(provider, frame);
            UpdateMallPageViewModel = CreateUpdateMallPageViewModel(provider, frame);
            WorkerViewModel = CreateWorkerViewModel(provider);
            LoginViewModel =  CreateLoginViewModel(provider, frame);
        }

        public LoginViewModel LoginViewModel { get; }

        public MallPageViewModel MallPageViewModel { get; }

        public AddMallPageViewModel AddMallPageViewModel { get; }

        public UpdateMallPageViewModel UpdateMallPageViewModel { get; }

        public MenuViewModel MenuViewModel { get; }

        public WorkerViewModel WorkerViewModel { get; }

        private LoginViewModel CreateLoginViewModel(IServiceProvider provider, Frame frame)
        {
            var dataContext = provider.GetRequiredService<RentMallDataContext>();
            var navigationService = provider.GetRequiredService<PageNavigationService>();

            return LoginViewModel.LoadViewModel(frame, dataContext, WorkerViewModel, navigationService,
                MenuViewModel, MallPageViewModel);
        }

        private MallPageViewModel CreateMallPageViewModel(IServiceProvider provider, Frame frame)
        {
            return MallPageViewModel.LoadViewModel(frame,
                provider.GetRequiredService<RentMallDataContext>(),
                provider.GetRequiredService<PageNavigationService>(),
                MenuViewModel,
                AddMallPageViewModel);
        }

        private AddMallPageViewModel CreateAddMallPageViewModel(IServiceProvider provider, Frame frame)
        {
            return AddMallPageViewModel.LoadViewModel(MallPageViewModel,
                MenuViewModel,
                provider.GetRequiredService<RentMallDataContext>(),
                frame,
                provider.GetRequiredService<PageNavigationService>());
        }

        private UpdateMallPageViewModel CreateUpdateMallPageViewModel(IServiceProvider provider, Frame frame)
        {
            return UpdateMallPageViewModel.LoadViewModel(MallPageViewModel,
                MenuViewModel,
                provider.GetRequiredService<RentMallDataContext>(),
                frame,
                provider.GetRequiredService<PageNavigationService>());
        }

        private WorkerViewModel CreateWorkerViewModel(IServiceProvider provider)
        {
            return WorkerViewModel.LoadViewModel(provider.GetRequiredService<RentMallDataContext>());
        }
    }
}
