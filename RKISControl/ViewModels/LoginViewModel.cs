using GalaSoft.MvvmLight.Command;
using RKISControl.Data;
using RKISControl.Services;
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

        private readonly MenuViewModel menuViewModel;

        private readonly MallPageViewModel mallPageViewModel;

        private readonly WorkerService workerViewModel;

        public LoginViewModel(Frame frame, 
            RentMallDataContext dataContext, 
            INavigateService navigateService,
            WorkerService workerViewModel, MallPageViewModel mallPageViewModel, MenuViewModel menuViewModel) : base(frame, dataContext, navigateService)
        {
            this.workerViewModel = workerViewModel;
            this.mallPageViewModel = mallPageViewModel;
            this.menuViewModel = menuViewModel;

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
            var worker = workerViewModel.GetWorker(Login, Password);

            var adminValidation = validatorService.Validate("Администратор", worker.Role);
            var managerAValidation = validatorService.Validate("Менеджер А", worker.Role);
            var managerCValidation = validatorService.Validate("Менеджер С", worker.Role);

            if (adminValidation || managerAValidation || managerCValidation)
            {
                SetValues(worker);
                NavigateService.NavigateToPage(new ManagerPageMenuView(Frame, menuViewModel, mallPageViewModel, NavigateService)
                {
                    DataContext = menuViewModel
                });
            }
            else
            {
                MessageBox.Show($"Роль сотрудника {worker.Second_Name} {worker.First_Name} {worker.Middle_Name} удалена!");
            }
        }

        private void SetValues(Worker worker)
        {
            menuViewModel.FirstName = worker.First_Name;
            menuViewModel.SecondName = worker.Second_Name;
            menuViewModel.LastName = worker.Middle_Name;
            menuViewModel.Role = worker.Role;
        }
    }
}
