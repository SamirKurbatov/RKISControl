namespace RKISControl.Services
{
    public interface IValidatorService
    {
        bool Validate(string role, string workerRole);
    }
}
