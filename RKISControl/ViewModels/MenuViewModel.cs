using RKISControl.Data;

namespace RKISControl.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private string role;
        public string Role
        {
            get => role;
            set
            {
                role = value;
                OnPropertyChanged();
            }
        }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }
    }
}
