using GalaSoft.MvvmLight.Command;
using RKISControl.Data;
using RKISControl.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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

            SelectedMall = new Mall();

            AddCommand = new RelayCommand(AddMall);
            RemoveCommand = new RelayCommand(RemoveMall);
        }

        public ObservableCollection<Mall> Malls => GetMalls();

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

        private void RemoveMall()
        {
            if (SelectedMall != null)
            {
                Malls.Remove(SelectedMall);

                db.Malls.Remove(SelectedMall);

                db.SaveChanges();

                OnPropertyChanged(nameof(Malls));
            }
            else
            {
                MessageBox.Show("Не выбран элемент или элемент уже удален! ");
            }
        }
    }
}
