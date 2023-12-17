﻿using RKISControl.Data;

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

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }

        private string secondName;
        public string SecondName
        {
            get => secondName;
            set
            {
                secondName = value;
                OnPropertyChanged();
            }
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }

        public string FullName => $"{FirstName} {SecondName} {LastName}";
    }
}
