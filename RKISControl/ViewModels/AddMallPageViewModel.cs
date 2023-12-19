using RKISControl.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Windows.Media;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System;
using System.Data.Entity;

namespace RKISControl.ViewModels
{
    public class AddMallPageViewModel : BaseViewModel
    {
        private readonly RentMallDataContext db;

        private readonly MallPageViewModel mallPageViewModel;

        public AddMallPageViewModel(MallPageViewModel mallPageViewModel, RentMallDataContext db)
        {
            this.mallPageViewModel = mallPageViewModel;
            this.db = db;

            CommitCommand = new RelayCommand(Commit);
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

        private void Commit()
        {
            try
            {
                var mall = new Mall()
                {
                    ID = Id,
                    Name = Name,
                    Status = Status,
                    Amount_P = Amount,
                    Town = Town,
                    Cost = Cost,
                    Coeff_cost = CoefCost,
                    Floor = Floor,
                    Image = PathImage
                };

                var malls = mallPageViewModel.Malls;

                malls.Add(mall);

                OnPropertyChanged(nameof(malls));

                db.Entry(mall).State = EntityState.Added;
                db.SaveChanges();

                MessageBox.Show("Данные добавлены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
