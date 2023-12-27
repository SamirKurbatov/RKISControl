using RKISControl.Data;
using RKISControl.ViewModels;
using System.Windows.Controls;

namespace RKISControl.Views
{
    public class TenantsPageViewModel : BaseViewModel
    {
        public TenantsPageViewModel(Frame frame, RentMallDataContext dataContext, INavigateService navigateService) : base(frame, dataContext, navigateService)
        {

        }
    }
}