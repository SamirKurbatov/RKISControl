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
        private readonly INavigationService navigationService;

        private readonly IValidatorService validatorService;

        private readonly Frame frame;

        private readonly RentMallDataContext db;

        private readonly MenuViewModel menuViewModel;

        private readonly MallPageViewModel mallPageViewModel;

        private readonly WorkerViewModel workerViewModel;

        public LoginViewModel(Frame frame, RentMallDataContext db, WorkerViewModel workerViewModel, INavigationService navigationService,
            MenuViewModel menuViewModel, MallPageViewModel mallPageViewModel)
        {
            this.frame = frame ?? throw new ArgumentNullException(nameof(frame));
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.workerViewModel = workerViewModel ?? throw new ArgumentNullException(nameof(workerViewModel));
            this.navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            this.menuViewModel = menuViewModel ?? throw new ArgumentNullException(nameof(menuViewModel));
            this.mallPageViewModel = mallPageViewModel ?? throw new ArgumentNullException(nameof(mallPageViewModel));

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

        public static LoginViewModel LoadViewModel(Frame frame, RentMallDataContext db, WorkerViewModel workerViewModel, INavigationService navigationService,
            MenuViewModel menuViewModel, MallPageViewModel mallPageViewModel)
        {
            var viewModel = new LoginViewModel(frame, db, workerViewModel, navigationService, menuViewModel, mallPageViewModel);

            return viewModel;
        }

        private void ShowAccountWindow()
        {
            var worker = workerViewModel.GetWorker(Login, Password);

            var adminValidation = validatorService.Validate("Администратор", worker.Role);
            var managerAValidation = validatorService.Validate("Менеджер А", worker.Role);
            var managerCValidation = validatorService.Validate("Менеджер С", worker.Role);

            if (adminValidation || managerAValidation || managerCValidation)
            {
                SetValues(worker);
                navigationService.NavigateToPage(new ManagerPageMenuView(frame, menuViewModel, mallPageViewModel, navigationService), menuViewModel);
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
