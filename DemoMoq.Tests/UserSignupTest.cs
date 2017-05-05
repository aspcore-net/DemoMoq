using DemoMoq.Models.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoMoq.Tests
{
    [TestClass]
    public class UserSignupTest
    {
        private Mock<IUserProfile> _moqClient;

        [TestInitialize]
        public void Initialize()
        {
            //Create a mock object
            _moqClient = new Mock<IUserProfile>();
            //Mock the properties
            _moqClient
                .SetupProperty(x => x.FirstName, "Anupam")
                .SetupProperty(x => x.LastName, "Shukla")
                .SetupProperty(x => x.CompanyName, "Successive Softwares")
                .SetupProperty(x => x.EmailAddress, "anupam@successivesoftwares.com")
                .SetupProperty(x => x.ConfirmEmailAddress, "anupam@successivesoftwares.com")
                .SetupProperty(x => x.Password, "123456")
                .SetupProperty(x => x.ConfirmPassword, "123456");
        }

        [TestMethod]
        public void TestSignup()
        {
            //Configure dummy method so that it return true when it gets any string as parameters to the method
            _moqClient.Setup(x => x.Signup()).Returns(1);
            //Use the mock object instead of actual object
            var result = _moqClient.Object.Signup();
            //Verify that it return true
            Assert.AreEqual(result, 1);
            //Verify that the Signup method gets called exactly once when string is passed as parameters
            _moqClient.Verify(x => x.Signup(), Times.Once);
        }

        [TestMethod]
        public void TestSendConfirmationEmail()
        {
            //Configure dummy method so that it return true when it gets any string as parameters to the method
            _moqClient.Setup(x => x.SendConfirmationEmail(It.IsAny<string>())).Returns(true);
            //Use the mock object instead of actual object
            var result = _moqClient.Object.SendConfirmationEmail(string.Empty);
            //Verify that it return true
            Assert.IsTrue(result);
            //Verify that the SendConfirmationEmail method gets called exactly once when string is passed as parameters
            _moqClient.Verify(x => x.SendConfirmationEmail(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void SendActivateAccount()
        {
            //Configure dummy method so that it return true when it gets any string as parameters to the method
            _moqClient.Setup(x => x.ActivateAccount(It.IsAny<string>())).Returns(true);
            //Use the mock object instead of actual object
            var result = _moqClient.Object.ActivateAccount(string.Empty);
            //Verify that it return true
            Assert.IsTrue(result);
            //Verify that the ActivateAccount method gets called exactly once when string is passed as parameters
            _moqClient.Verify(x => x.ActivateAccount(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void TestEmailAddress()
        {
            //Verify that EmailAddress and ConfirmEmailAddress are equal
            Assert.AreEqual(_moqClient.Object.EmailAddress, _moqClient.Object.ConfirmEmailAddress);
        }

        [TestMethod]
        public void TestPassword()
        {
            //Verify that Password and ConfirmPassword are equal
            Assert.AreEqual(_moqClient.Object.Password, _moqClient.Object.ConfirmPassword);
        }
    }
}
