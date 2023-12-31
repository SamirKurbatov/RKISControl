﻿using RKISControl.Data;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Linq;
using RKISControl.ViewModels.RKISControl.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System;

namespace RKISControl.ViewModels
{
    public class UpdateMallPageViewModel : BaseViewModel
    {
        public UpdateMallPageViewModel(Frame frame,
            RentMallDataContext dataContext,
            INavigateService navigateService,
            PageViewLocator pageViewLocator)
                : base(frame, dataContext, navigateService, pageViewLocator)
        {
            CommitCommand = new RelayCommand(Commit);
            BackToMallMenuCommand = new RelayCommand(BackToMallMenu);
        }

        #region Properties
        private int id;
        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string status;
        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }

        private int? amount;
        public int? Amount
        {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged();
            }
        }

        private string town;
        public string Town
        {
            get => town;
            set
            {
                town = value;
                OnPropertyChanged();
            }
        }

        private decimal? cost;
        public decimal? Cost
        {
            get => cost;
            set
            {
                cost = value;
                OnPropertyChanged();
            }
        }

        private double? coefCost;
        public double? CoefCost
        {
            get => coefCost;
            set
            {
                coefCost = value;
                OnPropertyChanged();
            }
        }

        private int? floor;
        public int? Floor
        {
            get => floor;
            set
            {
                floor = value;
                OnPropertyChanged();
            }
        }

        private string pathImage;
        public string PathImage
        {
            get => pathImage;
            set
            {
                pathImage = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ICommand CommitCommand { get; set; }

        public ICommand BackToMallMenuCommand { get; set; }

        private void BackToMallMenu()
        {
            PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.MallPageMenuView);
        }

        private void Commit()
        {
            if (Id >= 0 && DataContext != null)
            {
                var mallToUpdate = DataContext.Malls.FirstOrDefault(m => m.ID == Id);

                if (mallToUpdate != null)
                {
                    mallToUpdate.Name = Name;
                    mallToUpdate.Status = Status;
                    mallToUpdate.Amount_P = Amount;
                    mallToUpdate.Town = Town;
                    mallToUpdate.Cost = Cost;
                    mallToUpdate.Coeff_cost = CoefCost;
                    mallToUpdate.Floor = Floor;
                    mallToUpdate.Image = PathImage;

                    DataContext.SaveChanges();

                    MessageBox.Show("Данные успешно обновлены! ");

                    NavigateService.NavigateToPage(PageViewLocator.MallPageMenuView);
                }
                else
                {
                    MessageBox.Show($"Торговый центр с {Id} не найден! ");
                }

            }
            else
            {
                MessageBox.Show("Id или бд не заданы.");
            }
        }
    }
}
