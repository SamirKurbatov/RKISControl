using GalaSoft.MvvmLight.Command;
using RKISControl.Data;
using RKISControl.Services;
using RKISControl.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RKISControl.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;

        private readonly IValidatorService validatorService;

        private readonly Frame frame;

        private readonly RentMallDataContext db;

        private readonly ViewModelLocator viewModelLocator;

        public LoginViewModel(Frame frame, RentMallDataContext db, ViewModelLocator viewModelLocator, INavigationService navigationService)
        {
            this.frame = frame;
            this.db = db;
            this.viewModelLocator = viewModelLocator;
            this.navigationService = navigationService;

            validatorService = new NavigationValidatorService();

            LoginCommand = new RelayCommand(ShowAccountWindow);
        }


        private string login;
        public string Login
        {
            get => login;
            set
            {

                login = value;
                OnPropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        private void ShowAccountWindow()
        {
            var worker = viewModelLocator.WorkerViewModel.GetWorker(Login, Password);

            var adminValidation = validatorService.Validate("Администратор", worker.Role);
            var managerAValidation = validatorService.Validate("Менеджер А", worker.Role);
            var managerCValidation = validatorService.Validate("Менеджер С", worker.Role);

            if (adminValidation || managerAValidation || managerCValidation)
            {
                SetValues(worker);
                navigationService.NavigateToPage(new ManagerPageMenuView(frame, viewModelLocator, navigationService), viewModelLocator.MenuViewModel);
            }
            else
            {
                MessageBox.Show($"Роль сотрудника {worker.Second_Name} {worker.First_Name} {worker.Middle_Name} удалена!");
            }
        }

        private void SetValues(Worker worker)
        {
            viewModelLocator.MenuViewModel.FirstName = worker.First_Name;
            viewModelLocator.MenuViewModel.SecondName = worker.Second_Name;
            viewModelLocator.MenuViewModel.LastName = worker.Middle_Name;
            viewModelLocator.MenuViewModel.Role = worker.Role;
        }
    }
}
