using RKISControl.ViewModels.RKISControl.ViewModels;
using RKISControl.Views;

namespace RKISControl.Services.Factory
{
    public class PageViewFactory : IPageViewFactory
    {
        public AddMallPageView CreateAddMallPageView(PageViewLocator locator)
        {
            return new AddMallPageView(locator);
        }

        public LoginPageView CreateLoginView(PageViewLocator locator)
        {
            return new LoginPageView(locator);
        }

        public MallPageView CreateMallPageView(PageViewLocator locator)
        {
            return new MallPageView(locator);
        }

        public ManagerPageMenuView CreateManagerPageView(PageViewLocator locator)
        {
            return new ManagerPageMenuView(locator);
        }

        public MenuPageView CreateMenuPageView(PageViewLocator locator)
        {
            return new MenuPageView(locator);
        }

        public UpdateMenuPageView CreateUpdateMenuPage(PageViewLocator locator)
        {
            return new UpdateMenuPageView(locator);
        }
    }
}
