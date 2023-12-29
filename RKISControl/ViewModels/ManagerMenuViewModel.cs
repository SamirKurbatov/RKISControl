using CommunityToolkit.Mvvm.Input;
using RKISControl.Data;
using RKISControl.ViewModels.RKISControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace RKISControl.ViewModels
{
    public class ManagerMenuViewModel : BaseViewModel
    {
        public ManagerMenuViewModel(Frame frame, RentMallDataContext dataContext, INavigateService navigateService, PageViewLocator pageViewLocator) 
            : base(frame, dataContext, navigateService, pageViewLocator)
        {
            OpenTenantsWindowCommand = new RelayCommand(OpenTenantsWindow);
            BackToLoginCommand = new RelayCommand(BackToLogin);
        }

        #region Properties
        private string role;
        public string Role
        {
            get => role;
            set
            {
                role = value;
                OnPropertyChanged(nameof(Role));
            }
        }

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string secondName;
        public string SecondName
        {
            get => secondName;
            set
            {
                secondName = value;
                OnPropertyChanged(nameof(SecondName));
            }
        }

        private string lastName;

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string FullName => $"{FirstName} {SecondName} {LastName}";
        #endregion

        public ICommand OpenTenantsWindowCommand { get; set; }

        public ICommand BackToLoginCommand { get; set; }

        private void OpenTenantsWindow()
        {
            PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.TenantsPageView);
        }

        private void BackToLogin()
        {
            PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.LoginPageView);
        }
    }
}
