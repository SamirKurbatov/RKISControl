using RKISControl.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace RKISControl.ViewModels
{
    public class MallPageViewModel : BaseViewModel
    {
        private readonly RentMallDataContext db;

        public MallPageViewModel(RentMallDataContext db)
        {
            this.db = db;
        }

        private ObservableCollection<Mall> malls; // Galina@gmai.com 8KC7wJ
        public ObservableCollection<Mall> Malls
        {
            get => GetMalls();
            set
            {
                malls = value;
                OnPropertyChanged();
            }
        }

        public Mall SelectedMall { get; set; }

        public ObservableCollection<Mall> GetMalls()
        {
            return new ObservableCollection<Mall>(db.Malls.Select(m => m));
        }

        public ICommand AddCommand { get; set; }

        public ICommand RemoveCommand { get; set; }

        public ICommand UpdateCommand { get; set; }
    }
}
