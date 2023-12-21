using GalaSoft.MvvmLight.Command;
using RKISControl.Data;
using RKISControl.Views;
using System;
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
            SelectedMall = new Mall();

            this.frame = frame;
            this.db = db;
            this.viewModelLocator = viewModelLocator;

            OpenAddPageCommand = new RelayCommand(AddMall);
            RemoveCommand = new RelayCommand(RemoveMall);
            OpenUpdatePageCommand = new RelayCommand(ChangeMall);
        }

        public ObservableCollection<Mall> Malls => GetMalls();

        public Mall SelectedMall { get; set; } 

        private ObservableCollection<Mall> GetMalls()
        {
            return new ObservableCollection<Mall>(db.Malls.Select(m => m));
        }

        public ICommand OpenAddPageCommand { get; }

        public ICommand RemoveCommand { get; }

        public ICommand OpenUpdatePageCommand { get; }

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

        private void ChangeMall()
        {
            var updateMallPageViewModel = viewModelLocator.UpdateMallPageViewModel;

            if (SelectedMall != null)
            {
                frame.Navigate(new UpdateMenuPageView(frame, viewModelLocator)
                {
                    DataContext = updateMallPageViewModel
                });
            }
        }
    }
}
