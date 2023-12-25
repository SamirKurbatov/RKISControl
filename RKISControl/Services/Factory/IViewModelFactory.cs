using GalaSoft.MvvmLight.Views;
using RKISControl.Data;
using RKISControl.ViewModels;
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
        AddMallPageViewModel CreateAddMallPageViewModel(ViewModelLocator locator);

        LoginViewModel CreateLoginViewModel(ViewModelLocator locator);

        MallPageViewModel CreateMallPageViewModel(ViewModelLocator locator);

        MenuViewModel CreateMenuPageViewModel();

        UpdateMallPageViewModel CreateUpdateMallPageViewModel(ViewModelLocator locator);
    }
}
