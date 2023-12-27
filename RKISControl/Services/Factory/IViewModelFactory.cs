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
        AddMallPageViewModel CreateAddMallPageViewModel(PageViewLocator locator);

        LoginViewModel CreateLoginViewModel(PageViewLocator locator);

        MallPageViewModel CreateMallPageViewModel(PageViewLocator locator);

        MenuViewModel CreateMenuPageViewModel();

        UpdateMallPageViewModel CreateUpdateMallPageViewModel(PageViewLocator locator);

        WorkerService CreateWorkerService();
    }
}
