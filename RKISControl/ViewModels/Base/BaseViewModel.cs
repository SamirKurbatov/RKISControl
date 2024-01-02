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
        protected Frame Frame { get; set; }

        protected RentMallDataContext DataContext { get; set; }

        protected INavigateService NavigateService { get; set; }

        protected PageViewLocator PageViewLocator { get; set; }

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
