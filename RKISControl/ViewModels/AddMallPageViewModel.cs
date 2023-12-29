using RKISControl.Data;
using System.Windows.Input;
using System.Windows;
using System;
using System.Windows.Controls;
using RKISControl.ViewModels.RKISControl.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System.Data.Entity;

namespace RKISControl.ViewModels
{
    public class AddMallPageViewModel : BaseViewModel
    {
        public AddMallPageViewModel(Frame frame,
            RentMallDataContext dataContext,
            INavigateService navigateService, PageViewLocator pageViewLocator) : base(frame, dataContext, navigateService, pageViewLocator)
        {
            CommitCommand = new RelayCommand(Commit);
            BackCommand = new RelayCommand(Back);
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

        public ICommand BackCommand { get; set; }

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

                var malls = DataContext.Malls;

                malls.Add(mall);

                OnPropertyChanged(nameof(malls));

                DataContext.Entry(mall).State = EntityState.Added;

                DataContext.SaveChanges();

                MessageBox.Show("Данные добавлены!");

                PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.MallPageMenuView);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void Back()
        {
            PageViewLocator.NavigateService.NavigateToPage(PageViewLocator.MallPageMenuView);
        }
    }
}
