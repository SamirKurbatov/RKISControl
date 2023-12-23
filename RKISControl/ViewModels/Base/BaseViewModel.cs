using RKISControl.Data;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace RKISControl.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected Frame Frame { get; }
        
        protected RentMallDataContext DataContext { get; }
       
        protected INavigateService NavigateService { get; }

        public BaseViewModel(Frame frame, RentMallDataContext dataContext, INavigateService navigateService)
        {
            Frame = frame ?? throw new ArgumentNullException(nameof(frame));
            DataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            NavigateService = navigateService ?? throw new ArgumentNullException(nameof(navigateService));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
