using Microsoft.Extensions.DependencyInjection;
using RKISControl.Data;
using System;
using System.Windows.Controls;

namespace RKISControl.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IServiceProvider provider;

        private readonly Frame frame;

        private readonly RentMallDataContext db;

        private LoginViewModel loginViewModelInstance;

        public ViewModelLocator(Frame frame, IServiceProvider provider)
        {
            this.provider = provider;
            this.frame = frame;

            db = provider.GetRequiredService<RentMallDataContext>();
        }

        public LoginViewModel LoginViewModel
        {
            get
            {
                if (loginViewModelInstance == null)
                {
                    loginViewModelInstance = new LoginViewModel(frame, db, this);
                }
                return loginViewModelInstance;
            }
        }

        public MallPageViewModel MallPageViewModel => new MallPageViewModel(frame, db, this);

        public AddMallPageViewModel AddMallPageViewModel => new AddMallPageViewModel(this, db, frame);

        public UpdateMallPageViewModel UpdateMallPageViewModel => new UpdateMallPageViewModel(this, db, frame);

        public MenuViewModel MenuViewModel => provider.GetRequiredService<MenuViewModel>();

        public WorkerViewModel WorkerViewModel => new WorkerViewModel(db);
    }
}
