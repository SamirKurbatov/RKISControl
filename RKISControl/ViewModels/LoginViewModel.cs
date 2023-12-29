using CommunityToolkit.Mvvm.Input;
using RKISControl.Data;
using RKISControl.Services;
using RKISControl.ViewModels.RKISControl.ViewModels;
using RKISControl.Views;
using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RKISControl.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IValidatorService validatorService;

        public LoginViewModel(Frame frame,
            RentMallDataContext dataContext,
            INavigateService navigateService,
            PageViewLocator pageViewLocator) : base(frame, dataContext, navigateService, pageViewLocator)
        {
            validatorService = new NavigationValidatorService();

            LoginCommand = new RelayCommand(ShowAccountWindow);
        }

        #region Properties

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
        #endregion

        private void ShowAccountWindow()
        {
            var workerService = new WorkerService(DataContext);

            var worker = workerService.GetWorker(Login, Password);

            var adminValidation = validatorService.Validate("Администратор", worker.Role);
            var managerAValidation = validatorService.Validate("Менеджер А", worker.Role);
            var managerCValidation = validatorService.Validate("Менеджер С", worker.Role);

            if (adminValidation || managerAValidation || managerCValidation)
            {
                SetValues(worker);
                PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.MenuPageView);
            }
            else
            {
                MessageBox.Show($"Роль сотрудника {worker.Second_Name} {worker.First_Name} {worker.Middle_Name} удалена!");
            }
        }

        private void SetValues(Worker worker)
        {
            var menuViewModel = PageViewLocator.MenuPageView.DataContext as MenuViewModel;

            menuViewModel.FirstName = worker.First_Name;
            menuViewModel.SecondName = worker.Second_Name;
            menuViewModel.LastName = worker.Middle_Name;
            menuViewModel.Role = worker.Role;
        }

        public void HandlePasswordChanged(string newPassword)
        {
            Password = newPassword;
        }
    }
}
