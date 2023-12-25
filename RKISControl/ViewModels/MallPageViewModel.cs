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
        private readonly UpdateMallPageViewModel updateMallPageViewModel;

        private readonly AddMallPageViewModel addMallPageViewModel;

        private readonly MenuViewModel menuPageViewModel;

        public MallPageViewModel(Frame frame,
            RentMallDataContext dataContext,
            INavigateService navigateService,
            UpdateMallPageViewModel updateMallPageViewModel, AddMallPageViewModel addMallPageViewModel, MenuViewModel menuPageViewModel)
                : base(frame, dataContext, navigateService)
        {
            this.updateMallPageViewModel = new UpdateMallPageViewModel(frame, dataContext, navigateService, this, menuPageViewModel);
            this.addMallPageViewModel = new AddMallPageViewModel(frame, dataContext, navigateService, this, menuPageViewModel);
            this.menuPageViewModel = menuPageViewModel;

            SelectedMall = new Mall();


            OpenAddPageCommand = new RelayCommand(AddMall);
            RemoveCommand = new RelayCommand(RemoveMall);
            OpenUpdatePageCommand = new RelayCommand(ChangeMall);
        }

        public ObservableCollection<Mall> Malls => GetMalls();

        public Mall SelectedMall { get; set; }

        private ObservableCollection<Mall> GetMalls()
        {
            return new ObservableCollection<Mall>(DataContext.Malls.Select(m => m));
        }

        public ICommand OpenAddPageCommand { get; }

        public ICommand RemoveCommand { get; }

        public ICommand OpenUpdatePageCommand { get; }

        private void AddMall()
        {
            NavigateService.NavigateToPage(new AddMallPageView(Frame, NavigateService, this, menuPageViewModel)
            {
                DataContext = addMallPageViewModel
            });
        }

        private void RemoveMall()
        {
            if (SelectedMall != null)
            {
                Malls.Remove(SelectedMall);

                DataContext.Malls.Remove(SelectedMall);

                DataContext.SaveChanges();

                OnPropertyChanged(nameof(Malls));
            }
            else
            {
                MessageBox.Show("Не выбран элемент или элемент уже удален! ");
            }
        }

        private void ChangeMall()
        {
            if (SelectedMall != null)
            {
                NavigateService.NavigateToPage(new UpdateMenuPageView(Frame, NavigateService, this, menuPageViewModel)
                {
                    DataContext = updateMallPageViewModel
                });
            }
        }
    }
}
