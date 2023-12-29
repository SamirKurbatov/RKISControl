using RKISControl.Data;
using RKISControl.ViewModels.RKISControl.ViewModels;
using System.Windows.Controls;

namespace RKISControl.ViewModels
{
    public interface INavigateService
    {
        void NavigateToPage<T>(T page) where T : Page;
    }
}
