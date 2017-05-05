using System;
using DemoMoq.Models.Interfaces;

namespace DemoMoq.Models
{
    public class UserProfileModel : IUserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        public string ConfirmEmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public int Signup()
        {
            throw new NotImplementedException();
        }

        public bool SendConfirmationEmail(string activationLink)
        {
            throw new NotImplementedException();
        }

        public bool ActivateAccount(string activationLink)
        {
            throw new NotImplementedException();
        }
    }
}