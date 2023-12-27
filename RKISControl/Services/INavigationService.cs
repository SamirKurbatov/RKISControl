using RKISControl.Data;
using System.Windows.Controls;

namespace RKISControl.ViewModels
{
    public interface INavigateService
    {
        void NavigateToPage(Page view, MenuViewModel menuViewModel);
        void NavigateToPage(Page view, BaseViewModel viewModel);
    }
}
