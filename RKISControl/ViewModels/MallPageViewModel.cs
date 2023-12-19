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

        private ViewModelLocator viewModelLocator;

        public MallPageViewModel(Frame frame, RentMallDataContext db, ViewModelLocator viewModelLocator)
        {
            this.frame = frame;
            this.db = db;
            this.viewModelLocator = viewModelLocator;
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
            var addMallPageViewModel = viewModelLocator.AddMallPageViewModel;

            var addMallPageView = new AddMallPageView(frame, viewModelLocator)
            {
                DataContext = addMallPageViewModel
            };

            frame.Navigate(addMallPageView);
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
