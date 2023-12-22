using RKISControl.Services;
using System.Collections.Generic;

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
