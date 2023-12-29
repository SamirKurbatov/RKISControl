using CommunityToolkit.Mvvm.Input;
using RKISControl.Data;
using RKISControl.ViewModels;
using RKISControl.ViewModels.RKISControl.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RKISControl.Views
{
    public class TenantsViewModel : BaseViewModel
    {
        public TenantsViewModel(Frame frame, RentMallDataContext dataContext, INavigateService navigateService, PageViewLocator pageViewLocator) 
            : base(frame, dataContext, navigateService, pageViewLocator)
        {
            SelectedTenant = new Tenant();

            OpenAddTenantsPageCommand = new RelayCommand(OpenAddTenants);
            OpenChangeTenantsPageCommand = new RelayCommand(OpenChangeTenants);
            BackToMenuCommand = new RelayCommand(BackToMenu);
            RemoveTenantCommand = new RelayCommand(RemoveTenant);
        }

        public Tenant SelectedTenant { get; set; }

        public ObservableCollection<Tenant> Tenants => 
            new ObservableCollection<Tenant>(DataContext.Tenants.Select(x => x));

        public ICommand BackToMenuCommand { get; set; }

        public ICommand OpenAddTenantsPageCommand { get; set; }

        public ICommand OpenChangeTenantsPageCommand { get; set; }

        public ICommand RemoveTenantCommand { get; set; }

        private void BackToMenu()
        {
            PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.ManagerPageMenuView);
        }

        private void OpenAddTenants()
        {
            PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.AddTenantsPageView);
        }

        private void OpenChangeTenants()
        {
            PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.UpdateTenantsPageView);
        }

        private void RemoveTenant()
        {
            if (SelectedTenant != null)
            {
                Tenants.Remove(SelectedTenant);

                DataContext.Tenants.Remove(SelectedTenant);

                DataContext.SaveChanges();

                OnPropertyChanged(nameof(Tenants));
            }
            else
            {
                MessageBox.Show("Не выбран элемент или элемент уже удален! ");
            }
        }
    }
}