using CommunityToolkit.Mvvm.Input;
using RKISControl.Data;
using RKISControl.ViewModels.RKISControl.ViewModels;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace RKISControl.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel(Frame frame, RentMallDataContext dataContext, INavigateService navigateService, PageViewLocator pageViewLocator) 
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
                OnPropertyChanged();
            }
        }

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }

        private string secondName;
        public string SecondName
        {
            get => secondName;
            set
            {
                secondName = value;
                OnPropertyChanged();
            }
        }

        private string lastName;

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }

        public string FullName => $"{FirstName} {SecondName} {LastName}";
        #endregion

        public ICommand OpenTenantsWindowCommand { get; set; }

        public ICommand BackToLoginCommand { get; set; }

        private void OpenTenantsWindow()
        {
            PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.MallPageMenuView);
        }

        private void BackToLogin()
        {
            PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.LoginPageView);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
