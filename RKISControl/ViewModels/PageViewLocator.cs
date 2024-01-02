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

            private readonly IPageViewFactory pageFactory;

            private readonly IViewModelFactory viewModelFactory;

            public PageViewLocator(
                IPageViewFactory pageFactory,
                IViewModelFactory viewModelFactory,
                INavigateService navigateService)
            {
                
                this.pageFactory = pageFactory;

                this.viewModelFactory = viewModelFactory;

                NavigateService = navigateService;

                InitializeViews();
            }

            public LoginPageView LoginPageView { get; private set; }

            public MenuPageView MenuPageView { get; private set; }

            public ManagerPageMenuView ManagerPageMenuView { get; private set; }

            public MallPageView MallPageMenuView { get; private set; }

            public AddMallPageView AddMallPageView { get; private set; }

            public UpdateMenuPageView UpdateMenuPageView { get; private set; }

            public TenantsPageView TenantsPageView { get; private set; }

            public AddTenantsPageView AddTenantsPageView { get; private set; }

            public UpdateTenantsPageView UpdateTenantsPageView { get; private set; }

            private void InitializeViews()
            {
                LoginPageView = pageFactory.CreatePageView<LoginPageView, LoginViewModel>(this, viewModelFactory);
                MenuPageView = pageFactory.CreatePageView<MenuPageView, MenuViewModel>(this, viewModelFactory);
                TenantsPageView = pageFactory.CreatePageView<TenantsPageView, TenantsViewModel>(this, viewModelFactory);
                AddTenantsPageView = pageFactory.CreatePageView<AddTenantsPageView, AddTenantsViewModel>(this, viewModelFactory);
                UpdateTenantsPageView = pageFactory.CreatePageView<UpdateTenantsPageView, UpdateTenantsViewModel>(this, viewModelFactory);
                ManagerPageMenuView = pageFactory.CreatePageView<ManagerPageMenuView, ManagerMenuViewModel>(this, viewModelFactory);
                MallPageMenuView = pageFactory.CreatePageView<MallPageView, MallPageViewModel>(this, viewModelFactory);
                AddMallPageView = pageFactory.CreatePageView<AddMallPageView, AddMallPageViewModel>(this, viewModelFactory);
                UpdateMenuPageView = pageFactory.CreatePageView<UpdateMenuPageView, UpdateMallPageViewModel>(this, viewModelFactory);
            }

        }
    }

}
