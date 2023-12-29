using RKISControl.Data;
using RKISControl.ViewModels.RKISControl.ViewModels;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace RKISControl.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public Frame Frame { get; set; }

        public RentMallDataContext DataContext { get; set; }

        public INavigateService NavigateService { get; set; }

        public PageViewLocator PageViewLocator { get; set; }

        public BaseViewModel(Frame frame, RentMallDataContext dataContext, INavigateService navigateService, PageViewLocator pageViewLocator)
        {
            Frame = frame ?? throw new ArgumentNullException(nameof(frame));
            DataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            NavigateService = navigateService ?? throw new ArgumentNullException(nameof(navigateService));
            PageViewLocator = pageViewLocator ?? throw new ArgumentNullException(nameof(pageViewLocator)); ;
        }

        public BaseViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
