using Microsoft.Extensions.DependencyInjection;
using RKISControl.Data;
using RKISControl.ViewModels;
using RKISControl.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Controls;

namespace RKISControl.Services
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IServiceProvider _provider;

        private readonly RentMallDataContext dataContext;

        private readonly INavigateService navigationService;

        private readonly Frame _frame;

        public ViewModelFactory(IServiceProvider provider, Frame frame)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _frame = frame;

            dataContext = _provider.GetRequiredService<RentMallDataContext>();
            navigationService = _provider.GetRequiredService<PageNavigationService>();
        }

        public AddMallPageViewModel CreateAddMallPageViewModel(MallPageViewModel mallPageViewModel, MenuViewModel menuPageViewModel)
        {
            return new AddMallPageViewModel(_frame, dataContext,
                navigationService,
                mallPageViewModel, menuPageViewModel);
        }

        public LoginViewModel CreateLoginViewModel(MallPageViewModel mallPageViewModel, MenuViewModel menuPageViewModel)
        {
            var workerService = new WorkerService(dataContext);

            return new LoginViewModel(_frame, dataContext, navigationService, workerService, mallPageViewModel, menuPageViewModel);
        }

        public MallPageViewModel CreateMallPageViewModel(UpdateMallPageViewModel updateMallPageViewModel, AddMallPageViewModel addMallPageViewModel, MenuViewModel menuViewModel)
        {
            return new MallPageViewModel(_frame, dataContext, navigationService, updateMallPageViewModel, addMallPageViewModel, menuViewModel);
        }

        public MenuViewModel CreateMenuPageViewModel()
        {
            return new MenuViewModel();
        }

        public UpdateMallPageViewModel CreateUpdateMallPageViewModel(MallPageViewModel mallPageViewModel, MenuViewModel menuViewModel)
        {
            return new UpdateMallPageViewModel(_frame, dataContext, navigationService, mallPageViewModel, menuViewModel);
        }
    }
}
