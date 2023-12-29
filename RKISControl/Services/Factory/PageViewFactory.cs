using RKISControl.ViewModels;
using RKISControl.ViewModels.RKISControl.ViewModels;
using RKISControl.Views;
using System;
using System.Windows.Controls;

namespace RKISControl.Services.Factory
{
    public class PageViewFactory : IPageViewFactory
    {
        public T CreatePageView<T, VM>(PageViewLocator locator, IViewModelFactory viewModelFactory)
            where T : Page
            where VM : BaseViewModel
        {
            T page = Activator.CreateInstance<T>();

            VM viewModel = viewModelFactory.CreateViewModel<VM>(locator);

            page.DataContext = viewModel;

            return page;
        }
    }
}
