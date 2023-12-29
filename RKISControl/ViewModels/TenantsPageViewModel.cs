using CommunityToolkit.Mvvm.Input;
using RKISControl.Data;
using RKISControl.ViewModels;
using RKISControl.ViewModels.RKISControl.ViewModels;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace RKISControl.Views
{
    public class TenantsPageViewModel : BaseViewModel
    {
        public TenantsPageViewModel(Frame frame, RentMallDataContext dataContext, INavigateService navigateService, PageViewLocator pageViewLocator) 
            : base(frame, dataContext, navigateService, pageViewLocator)
        {
            BackToMenuCommand = new RelayCommand(BackToMenu);
        }

        private void BackToMenu()
        {
            PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.ManagerPageMenuView);
        }

        public ICommand BackToMenuCommand { get; set; }
    }
}