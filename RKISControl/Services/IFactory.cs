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
        AddMallPageViewModel CreateAddMallPageViewModel(MallPageViewModel mallPageViewModel, MenuViewModel menuPageViewModel);

        LoginViewModel CreateLoginViewModel(MallPageViewModel mallPageViewModel, MenuViewModel menuPageViewModel);

        MallPageViewModel CreateMallPageViewModel(UpdateMallPageViewModel updateMallPageViewModel, AddMallPageViewModel addMallPageViewModel, MenuViewModel menuViewModel);

        MenuViewModel CreateMenuPageViewModel();

        UpdateMallPageViewModel CreateUpdateMallPageViewModel(MallPageViewModel mallPageViewModel, MenuViewModel menuViewModel);
    }
}
