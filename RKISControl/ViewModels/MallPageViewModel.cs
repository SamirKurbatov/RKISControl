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
using System.Windows.Navigation;

namespace RKISControl.ViewModels
{
    public class MallPageViewModel : BaseViewModel
    {
        private readonly RentMallDataContext db;

        private readonly Frame frame;

        private readonly ViewModelLocator viewModelLocator;

        private readonly INavigationService navigationService;

        public MallPageViewModel(Frame frame, RentMallDataContext db, ViewModelLocator viewModelLocator, INavigationService navigationService)
        {
            SelectedMall = new Mall();

            this.frame = frame;
            this.db = db;
            this.viewModelLocator = viewModelLocator;
            this.navigationService = navigationService;

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

            navigationService.NavigateToPage(new AddMallPageView(frame, viewModelLocator, navigationService), addMallPageViewModel);
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
                navigationService.NavigateToPage(new UpdateMenuPageView(frame, viewModelLocator, navigationService), updateMallPageViewModel);
            }
        }
    }
}
