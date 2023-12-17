
using GalaSoft.MvvmLight.Command;
using RKISControl.Data;
using RKISControl.Views;
using System;
using System.Linq;
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

        public LoginViewModel(Frame frame, WorkerViewModel workerViewModel, MenuViewModel menuViewModel)
        {
            this.frame = frame;
            this.workerViewModel = workerViewModel ?? throw new ArgumentNullException(nameof(workerViewModel));
            this.menuViewModel = menuViewModel ?? throw new ArgumentNullException(nameof(menuViewModel));

            LoginCommand = new RelayCommand(GetLogin);
        }


        private string login = "sdasadsa";
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }

        private string password = "dsadsadasdsadsadsada";
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

            if (worker != null || worker.Role == "Администратор")
            {
                menuViewModel.Role = "Администратор";
                frame.Navigate(new MenuPageView(frame)
                {
                    DataContext = menuViewModel
                });
            }

            else if (worker != null || worker.Role == "Менеджер А")
            {
                menuViewModel.Role = "Менеджер A";
                frame.Navigate(new ManagerPageMenuView(frame)
                {
                    DataContext = menuViewModel
                });
            }

            else if (worker != null || worker.Role == "Менеджер C")
            {
                menuViewModel.Role = "Менеджер С";
                frame.Navigate(new ManagerPageMenuView(frame)
                {
                    DataContext = menuViewModel
                });
            }

            else
            {
                MessageBox.Show("Пользователь удален! ");
            }
        }
    }

    public class WorkerViewModel
    {
        private RentMallDataContext db;

        public WorkerViewModel(RentMallDataContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Worker GetWorker(string login, string password)
        {
            return db.Workers.FirstOrDefault(w => w.Password == password && w.Login == login);
        }
    }
}
