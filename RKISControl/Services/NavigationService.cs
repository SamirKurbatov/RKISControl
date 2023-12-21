using RKISControl.Data;
using RKISControl.Services;
using RKISControl.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RKISControl.ViewModels
{
    public class NavigationService : INavigationService
    {
        private IValidatorService validatorService;
        private readonly Frame frame;
        private readonly ViewModelLocator viewModelLocator;

        public NavigationService(Frame frame, ViewModelLocator viewModelLocator)
        {
            this.frame = frame;
            this.viewModelLocator = viewModelLocator;

            validatorService = new NavigationValidatorService();
        }

        public void NavigateToMenu(Worker worker)
        {
            viewModelLocator.MenuViewModel.FirstName = worker.First_Name;
            viewModelLocator.MenuViewModel.SecondName = worker.Second_Name;
            viewModelLocator.MenuViewModel.LastName = worker.Middle_Name;

            viewModelLocator.MenuViewModel.Role = worker.Role;

            NavigateToPage(new ManagerPageMenuView(frame, viewModelLocator)
            {
                DataContext = viewModelLocator.MenuViewModel
            });
        }

        private void NavigateToPage(Page view)
        {
            frame.Navigate(view);
        }
    }
}

public class NavigationValidatorService : IValidatorService
{
    private readonly HashSet<string> roles;

    public NavigationValidatorService()
    {
        roles = new HashSet<string>
            {
                "Администратор",
                "Менеджер А",
                "Менеджер С"
            };
    }

    public bool Validate(string role, string workerRole)
    {
        if (roles.Contains(role) && IsConsidenseRole(role, workerRole))
        {
            return IsConsidenseRole(role, workerRole);
        }
        return false;
    }

    private bool IsConsidenseRole(string comparedRole, string workerRole)
    {
        return comparedRole == workerRole;
    }
}
