using RKISControl.Data;
using RKISControl.ViewModels;
using RKISControl.ViewModels.RKISControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace RKISControl.Services
{
    public interface IViewModelFactory
    {
        T CreateViewModel<T>(PageViewLocator pageViewLocator) where T : BaseViewModel;
    }
}
