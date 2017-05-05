using DemoMoq.Models;
using DemoMoq.Models.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoMoq.Tests
{
    [TestClass]
    public class MailerTest
    {
        [TestMethod]
        public void SendEmailTest()
        {
            //Create a mock object
            var mockClient = new Mock<IMailClient>();
            //Mock the properties
            mockClient.SetupProperty(x => x.Server, "smtp.xyz.com")
                .SetupProperty(x => x.Port, "25");
            //Configure dummy method so that it return true when it gets any string as parameters to the method
            mockClient.Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);
            var mailer = new DefaultMailer
            {
                From = "from@xyz.com",
                To = "to@xyz.com",
                Subject = "Test subject",
                Body = "Test moq framework"
            };
            //Use the mock object instead of actual object
            var result = mailer.SendMail(mockClient.Object);
            //Verify that it return true
            Assert.IsTrue(result);
            //Verify that the SendMail method gets called exactly once when string is passed as parameters
            mockClient.Verify(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
