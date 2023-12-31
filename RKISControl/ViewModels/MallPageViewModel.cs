﻿using CommunityToolkit.Mvvm.Input;
using RKISControl.Commands;
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
        public MallPageViewModel(Frame frame,
            RentMallDataContext dataContext,
            INavigateService navigateService,
            PageViewLocator pageViewLocator)
                : base(frame, dataContext, navigateService, pageViewLocator)
        {
            SelectedMall = new Mall();

            OpenAddPageCommand = new RelayCommand(OpenAddMall);
            RemoveCommand = new RelayCommandAsync(RemoveMall);
            OpenUpdatePageCommand = new RelayCommand(OpenChangeMall);
            BackCommand = new RelayCommand(BackToLogin);
        }

        private ObservableCollection<Mall> malls;
        public ObservableCollection<Mall> Malls
        {
            get => malls;
            set
            {
                malls = value;
                OnPropertyChanged();
            }
        }

        public Mall SelectedMall { get; set; }


        public async Task LoadMallsAsync()
        {
            var malls = await DataContext.Malls.Select(x => x).ToListAsync();
            Malls = new ObservableCollection<Mall>(malls);
        }

        public ICommand OpenAddPageCommand { get; }

        public ICommand RemoveCommand { get; }

        public ICommand OpenUpdatePageCommand { get; }

        public ICommand BackCommand { get; set; }

        private void BackToLogin()
        {
            PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.MenuPageView);
        }

        private void OpenAddMall()
        {
            PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.AddMallPageView);
        }

        private async Task RemoveMall()
        {
            if (SelectedMall != null)
            {
                Malls.Remove(SelectedMall);

                DataContext.Malls.Remove(SelectedMall);

                await DataContext.SaveChangesAsync();

                Application.Current.Dispatcher.Invoke(() =>
                {
                    OnPropertyChanged(nameof(Malls));
                });
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
                PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.UpdateMenuPageView);
            }
        }
    }
}
