using CommunityToolkit.Mvvm.Input;
using RKISControl.Commands;
using RKISControl.Data;
using RKISControl.ViewModels;
using RKISControl.ViewModels.RKISControl.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
            RemoveTenantCommand = new RelayCommandAsync(RemoveTenant);
        }

        public Tenant SelectedTenant { get; set; }

        private ObservableCollection<Tenant> tenants;
        public ObservableCollection<Tenant> Tenants
        {
            get => tenants;
            set
            {
                tenants = value;
                OnPropertyChanged();
            }
        }

        public ICommand BackToMenuCommand { get; set; }

        public ICommand OpenAddTenantsPageCommand { get; set; }

        public ICommand OpenChangeTenantsPageCommand { get; set; }

        public ICommand RemoveTenantCommand { get; set; }

        public async Task LoadTenantsAsync()
        {
            var tenants = await DataContext.Tenants.Select(x => x).ToListAsync();
            Tenants = new ObservableCollection<Tenant>(tenants);
        }

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

        private async Task RemoveTenant()
        {
            if (SelectedTenant != null)
            {
                DataContext.Tenants.Remove(SelectedTenant);

                Tenants.Remove(SelectedTenant);

                await DataContext.SaveChangesAsync();

                Application.Current.Dispatcher.Invoke(() =>
                {
                    OnPropertyChanged(nameof(Tenants));
                });
            }
            else
            {
                MessageBox.Show("Не выбран элемент или элемент уже удален! ");
            }
        }
    }
}