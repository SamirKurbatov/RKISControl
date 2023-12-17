
using RKISControl.Data;
using System;
using System.Linq;
using System.Windows.Controls;

namespace RKISControl.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly WorkerViewModel workerViewModel;
        private readonly MenuViewModel menuViewModel;

        public LoginViewModel(WorkerViewModel workerViewModel, MenuViewModel menuViewModel)
        {
            this.workerViewModel = workerViewModel ?? throw new ArgumentNullException(nameof(workerViewModel));
            this.menuViewModel = menuViewModel ?? throw new ArgumentNullException(nameof(menuViewModel));
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

        public Worker Worker
        {
            get
            {
                return workerViewModel.GetWorker(Password, menuViewModel?.Role);
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

        public Worker GetWorker(string password, string role)
        {
            return db.Workers.FirstOrDefault(w => w.Password == password && w.Role == role);
        }
    }
}
