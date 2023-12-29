using CommunityToolkit.Mvvm.Input;
using RKISControl.Data;
using RKISControl.ViewModels.RKISControl.ViewModels;
using System.Data.Entity;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System;

namespace RKISControl.ViewModels
{
    public class AddTenantsViewModel : BaseViewModel
    {
        public AddTenantsViewModel(Frame frame,
    RentMallDataContext dataContext,
    INavigateService navigateService, PageViewLocator pageViewLocator) : base(frame, dataContext, navigateService, pageViewLocator)
        {
            CommitCommand = new RelayCommand(Commit);
            BackCommand = new RelayCommand(Back);
        }

        #region Properties
        private int id;
        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }


        private string adress;
        public string Adress
        {
            get => adress;
            set
            {
                adress = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ICommand CommitCommand { get; set; }

        public ICommand BackCommand { get; set; }

        private void Commit()
        {
            try
            {
                var tenant = new Tenant()
                {
                    ID = Id,
                    Name = Title,
                    Phone = phoneNumber,
                    Adress = Adress
                };

                var tenants = DataContext.Tenants;

                tenants.Add(tenant);

                OnPropertyChanged(nameof(tenants));

                DataContext.Entry(tenant).State = EntityState.Added;

                DataContext.SaveChanges();

                MessageBox.Show("Данные добавлены!");

                PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.TenantsPageView);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void Back()
        {
            PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.TenantsPageView);
        }
    }
}
