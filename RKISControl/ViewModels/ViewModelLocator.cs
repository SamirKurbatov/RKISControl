using Microsoft.Extensions.DependencyInjection;
using RKISControl.Data;
using System;
using System.Windows.Controls;

namespace RKISControl.ViewModels
{
    public class ViewModelLocator
    {
        private readonly Frame frame;

        private readonly IServiceProvider provider;

        private readonly INavigationService navigationService;

        private readonly RentMallDataContext db;

        public ViewModelLocator(Frame frame, IServiceProvider provider, INavigationService navigationService)
        {
            this.provider = provider;
            this.frame = frame;
            this.navigationService = navigationService;

            db = provider.GetRequiredService<RentMallDataContext>();
        }

        private LoginViewModel loginViewModelInstance;

        public LoginViewModel LoginViewModel
        {
            get
            {
                if (loginViewModelInstance == null)
                {
                    loginViewModelInstance = new LoginViewModel(frame, db, this, navigationService);
                }
                return loginViewModelInstance;
            }
        }

        public MallPageViewModel MallPageViewModel => new MallPageViewModel(frame, db, this, navigationService);

        public AddMallPageViewModel AddMallPageViewModel => new AddMallPageViewModel(this, db, frame, navigationService);

        public UpdateMallPageViewModel UpdateMallPageViewModel => new UpdateMallPageViewModel(this, db, frame, navigationService);

        public MenuViewModel MenuViewModel => provider.GetRequiredService<MenuViewModel>();

        public WorkerViewModel WorkerViewModel => new WorkerViewModel(db);
    }
}
