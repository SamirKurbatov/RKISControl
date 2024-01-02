using CommunityToolkit.Mvvm.Input;
using RKISControl.Data;
using RKISControl.ViewModels.RKISControl.ViewModels;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace RKISControl.ViewModels
{
    public class UpdateTenantsViewModel : BaseViewModel
    {
        public UpdateTenantsViewModel(Frame frame,
            RentMallDataContext dataContext,
            INavigateService navigateService,
            PageViewLocator pageViewLocator)
                : base(frame, dataContext, navigateService, pageViewLocator)
        {
            CommitCommand = new RelayCommand(Commit);
            BackToTenantsMenuCommand = new RelayCommand(BackToTenantsMenu);
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

        public ICommand BackToTenantsMenuCommand { get; set; }

        private void BackToTenantsMenu()
        {
            PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.TenantsPageView);
        }

        private void Commit()
        {
            if (Id >= 0 && DataContext != null)
            {
                var tenantToUpdate = DataContext.Tenants.FirstOrDefault(t => t.ID == Id);

                if (tenantToUpdate != null)
                {
                    tenantToUpdate.Name = Title;
                    tenantToUpdate.Adress = Adress;
                    tenantToUpdate.Phone = PhoneNumber;

                    DataContext.SaveChanges();

                    MessageBox.Show("Данные успешно обновлены! ");

                    NavigateService.NavigateToPage(PageViewLocator.TenantsPageView);
                }
                else
                {
                    MessageBox.Show($"Арендатор с {Id} не найден! ");
                }

            }
            else
            {
                MessageBox.Show("Id или бд не заданы.");
            }
        }
    }
}
