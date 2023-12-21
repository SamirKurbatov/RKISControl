using RKISControl.Data;
using RKISControl.Services;
using System;
using System.Linq;
using System.Windows;

namespace RKISControl.ViewModels
{
    public class WorkerViewModel
    {
        private RentMallDataContext db;

        public WorkerViewModel(RentMallDataContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Worker GetWorker(string login, string password)
        {
            return db.Workers.Where(w => w.Password == password && w.Login == login).FirstOrDefault();
        }
    }
}
