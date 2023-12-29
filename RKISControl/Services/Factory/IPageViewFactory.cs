using RKISControl.ViewModels;
using RKISControl.ViewModels.RKISControl.ViewModels;
using RKISControl.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RKISControl.Services.Factory
{
    public interface IPageViewFactory : IFactory
    {
        T CreatePageView<T, VM>(PageViewLocator locator, IViewModelFactory viewModelFactory)
          where T : Page
          where VM : BaseViewModel;
    }
}
