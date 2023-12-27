using RKISControl.ViewModels.RKISControl.ViewModels;
using RKISControl.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKISControl.Services.Factory
{
    public interface IPageViewFactory : IFactory
    {
        AddMallPageView CreateAddMallPageView(PageViewLocator locator);

        LoginPageView CreateLoginView(PageViewLocator locator);

        MallPageView CreateMallPageView(PageViewLocator locator);

        MenuPageView CreateMenuPageView(PageViewLocator locator);

        ManagerPageMenuView CreateManagerPageView(PageViewLocator locator);

        UpdateMenuPageView CreateUpdateMenuPage(PageViewLocator locator);
    }
}
