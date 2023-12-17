
using GalaSoft.MvvmLight.Command;
using RKISControl.Data;
using RKISControl.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RKISControl.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly Frame frame;

        private readonly WorkerViewModel workerViewModel;

        private readonly MenuViewModel menuViewModel;

        public LoginViewModel(Frame frame)
        {
            this.frame = frame;

            var db = new RentMallDataContext();

            this.workerViewModel = new WorkerViewModel(db);

            this.menuViewModel = new MenuViewModel();

            LoginCommand = new RelayCommand(GetLogin);
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

        private void GetLogin()
        {
            var worker = workerViewModel.GetWorker(Login, Password);

            if (worker != null && worker.Role == "Администратор")
            {
                SetFullNameWorker(worker);

                menuViewModel.Role = "Администратор";
                frame.Navigate(new MenuPageView(frame, this)
                {
                    DataContext = menuViewModel
                });
            }

            else if (worker != null && worker.Role == "Менеджер А")
            {

                SetFullNameWorker(worker);

                menuViewModel.Role = "Менеджер А";
                frame.Navigate(new ManagerPageMenuView(frame, this)
                {
                    DataContext = menuViewModel
                });

            }
            else if (worker != null && worker.Role == "Менеджер С")
            {
                SetFullNameWorker(worker);

                menuViewModel.Role = "Менеджер С";
                frame.Navigate(new ManagerPageMenuView(frame, this)
                {
                    DataContext = menuViewModel
                });
            }

            else
            {
                MessageBox.Show("Пользователь удален! ");
            }
        }

        private void SetFullNameWorker(Worker worker)
        {
            menuViewModel.FirstName = worker.First_Name;
            menuViewModel.SecondName = worker.Second_Name;
            menuViewModel.LastName = worker.Middle_Name;
        }
    }
}
