using Microsoft.Extensions.DependencyInjection;
using RKISControl.Services;
using RKISControl.Services.Factory;
using RKISControl.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKISControl.ViewModels
{
    namespace RKISControl.ViewModels
    {
        public class PageViewLocator
        {
            public INavigateService NavigateService { get; }

            public IPageViewFactory PageFactory { get; }

            private readonly IViewModelFactory viewModelFactory;

            public PageViewLocator(IServiceProvider serviceProvider)
            {
                PageFactory = serviceProvider.GetRequiredService<PageViewFactory>();

                viewModelFactory = serviceProvider.GetRequiredService<ViewModelFactory>();

                NavigateService = serviceProvider.GetRequiredService<PageNavigationService>();

                InitializeViews();
            }

            public LoginPageView LoginPageView { get; private set; }

            public MenuPageView MenuPageView { get; private set; }

            public ManagerPageMenuView ManagerPageMenuView { get; private set; }

            public MallPageView MallPageMenuView { get; private set; }

            public AddMallPageView AddMallPageView { get; private set; }

            public UpdateMenuPageView UpdateMenuPageView { get; private set; }

            public TenantsPageView TenantsPageView { get; private set; }

            public MenuViewModel MenuViewContextModel
                => MenuPageView.DataContext as MenuViewModel;

            private void InitializeViews()
            {
                LoginPageView = PageFactory.CreateLoginView(this);
                LoginPageView.DataContext = viewModelFactory.CreateLoginViewModel(this);

                MenuPageView = PageFactory.CreateMenuPageView(this);
                MenuPageView.DataContext = viewModelFactory.CreateMenuPageViewModel();

                ManagerPageMenuView = PageFactory.CreateManagerPageView(this);
                ManagerPageMenuView.DataContext = viewModelFactory.CreateMenuPageViewModel();

                MallPageMenuView = PageFactory.CreateMallPageView(this);
                MallPageMenuView.DataContext = viewModelFactory.CreateMallPageViewModel(this);

                AddMallPageView = PageFactory.CreateAddMallPageView(this);
                AddMallPageView.DataContext = viewModelFactory.CreateAddMallPageViewModel(this);

                UpdateMenuPageView = PageFactory.CreateUpdateMenuPage(this);
                UpdateMenuPageView.DataContext = viewModelFactory.CreateUpdateMallPageViewModel(this);
            }

        }
    }

}
