using Microsoft.Extensions.DependencyInjection;
using RKISControl.Data;
using RKISControl.ViewModels;
using RKISControl.ViewModels.RKISControl.ViewModels;
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

        public T CreateViewModel<T>(PageViewLocator pageViewLocator) where T : BaseViewModel
        {
            T viewModel = (T)Activator.CreateInstance(typeof(T), _frame, dataContext, navigationService, pageViewLocator);

            return viewModel;
        }
    }
}
