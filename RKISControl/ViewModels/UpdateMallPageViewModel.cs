using RKISControl.Data;
using RKISControl.Views;
using System.Data.Entity;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System;
using GalaSoft.MvvmLight.Command;
using System.Linq;

namespace RKISControl.ViewModels
{
    public class UpdateMallPageViewModel : BaseViewModel
    {
        private readonly RentMallDataContext db;

        private readonly ViewModelLocator viewModelLocator;

        private readonly Frame frame;

        public UpdateMallPageViewModel(ViewModelLocator viewModelLocator, RentMallDataContext db, Frame frame)
        {
            this.viewModelLocator = viewModelLocator;

            this.db = db;

            this.frame = frame;

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
            if (Id > 0 && db != null)
            {
                var mallToUpdate = db.Malls.FirstOrDefault(m => m.ID == Id);

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

                    db.SaveChanges();

                    MessageBox.Show("Данные успешно обновлены! ");
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
