﻿using CommunityToolkit.Mvvm.Input;
using RKISControl.Data;
using RKISControl.ViewModels.RKISControl.ViewModels;
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
        private readonly PageViewLocator pageViewLocator;

        public MallPageViewModel(Frame frame,
            RentMallDataContext dataContext,
            INavigateService navigateService,
            PageViewLocator pageViewLocator)
                : base(frame, dataContext, navigateService)
        {
            this.pageViewLocator = pageViewLocator;

            SelectedMall = new Mall();


            OpenAddPageCommand = new RelayCommand(OpenAddMall);
            RemoveCommand = new RelayCommand(RemoveMall);
            OpenUpdatePageCommand = new RelayCommand(OpenChangeMall);
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

        private void OpenAddMall()
        {
            NavigateService.NavigateToPage(pageViewLocator.AddMallPageView);
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

        private void OpenChangeMall()
        {
            if (SelectedMall != null)
            {
                pageViewLocator.NavigateService.NavigateToPage(pageViewLocator.UpdateMenuPageView);
            }
        }
    }
}
