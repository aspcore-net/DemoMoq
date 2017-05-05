namespace DemoMoq.Models.Interfaces
{
    public interface IUserProfile
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string CompanyName { get; set; }
        string EmailAddress { get; set; }
        string ConfirmEmailAddress { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }

        int Signup();
        bool SendConfirmationEmail(string activationLink);
        bool ActivateAccount(string activationLink);
    }
}
