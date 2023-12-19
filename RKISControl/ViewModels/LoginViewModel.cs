
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

        private readonly RentMallDataContext db;

        private readonly ViewModelLocator viewModelLocator;

        public LoginViewModel(Frame frame, RentMallDataContext db, ViewModelLocator viewModelLocator)
        {
            this.frame = frame;
            this.db = db;
            this.viewModelLocator = viewModelLocator;

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
            var worker = viewModelLocator.WorkerViewModel.GetWorker(Login, Password);

            if (worker != null && worker.Role == "Администратор")
            {
                SetFullNameWorker(worker);

                viewModelLocator.MenuViewModel.Role = "Администратор";
                frame.Navigate(new MenuPageView(frame, viewModelLocator)
                {
                    DataContext = viewModelLocator.MenuViewModel
                });
            }

            else if (worker != null && worker.Role == "Менеджер А")
            {
                SetFullNameWorker(worker);

                viewModelLocator.MenuViewModel.Role = "Менеджер А";
                frame.Navigate(new ManagerPageMenuView(frame, viewModelLocator)
                {
                    DataContext = viewModelLocator.MenuViewModel
                });

            }
            else if (worker != null && worker.Role == "Менеджер С")
            {
                SetFullNameWorker(worker);

                viewModelLocator.MenuViewModel.Role = "Менеджер С";
                frame.Navigate(new ManagerPageMenuView(frame, viewModelLocator)
                {
                    DataContext = viewModelLocator.MenuViewModel
                });
            }

            else
            {
                MessageBox.Show("Пользователь удален! ");
            }
        }

        private void SetFullNameWorker(Worker worker)
        {
            viewModelLocator.MenuViewModel.FirstName = worker.First_Name;
            viewModelLocator.MenuViewModel.SecondName = worker.Second_Name;
            viewModelLocator.MenuViewModel.LastName = worker.Middle_Name;
        }
    }
}
