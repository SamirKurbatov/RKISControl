using RKISControl.Data;
using System.Windows.Controls;

namespace RKISControl.ViewModels
{
    public interface INavigationService
    {
        void NavigateToPage(Page view);
        void NavigateToPage(Page view, BaseViewModel viewModel);
    }
}
