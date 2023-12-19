using GalaSoft.MvvmLight.Command;
using RKISControl.Data;
using RKISControl.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace RKISControl.ViewModels
{
    public class MallPageViewModel : BaseViewModel
    {
        private readonly RentMallDataContext db;

        private readonly Frame frame;

        public MallPageViewModel(Frame frame, RentMallDataContext db)
        {
            this.frame = frame;
            this.db = db;

            AddCommand = new RelayCommand(AddMall);
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

        private ObservableCollection<Mall> GetMalls()
        {
            return new ObservableCollection<Mall>(db.Malls.Select(m => m));
        }

        public ICommand AddCommand { get; }

        public ICommand RemoveCommand { get; }

        public ICommand UpdateCommand { get; }

        private void AddMall()
        {
            frame.Navigate(new AddMallPageView(frame, this)
            {
                DataContext = new AddMallPageViewModel(this, db)
            });
        }
    }
}
