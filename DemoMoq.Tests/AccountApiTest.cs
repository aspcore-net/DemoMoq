using DemoMoq.ApiControllers;
using DemoMoq.DataLayer;
using DemoMoq.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoMoq.Tests
{
    [TestClass]
    public class AccountApiTest
    {
        [TestMethod]
        public void TestInsert()
        {
            //Create a mock object for IUnitOfWorkManager
            var moqUnitOfWorkManager = new Mock<IUnitOfWorkManager>();
            //Create a mock object for UserProfileModel
            var moqRepository = new Mock<IRepository<UserProfileModel>>();
            //Configure dummy method so that it return 1 when it gets any object of UserProfileModel as parameters to the method
            moqRepository.Setup(x => x.Insert(It.IsAny<UserProfileModel>())).Returns(() => new UserProfileModel { Id = 1 });
            var controller = new AccountController(moqUnitOfWorkManager.Object, moqRepository.Object);
            var userModel = new UserProfileModel
            {
                FirstName = "Anupam",
                LastName = "Shukla",
                CompanyName = "Successive Softwares",
                EmailAddress = "anupam@successivesoftwares.com",
                Password = "123456"
            };
            var result = controller.Post(userModel);
            //Verify that it return 1
            Assert.AreEqual(result, 1);
            //Verify that the Insert method gets called exactly once when UserProfileModel object is passed as parameters
            moqRepository.Verify(x => x.Insert(It.IsAny<UserProfileModel>()), Times.Once);
        }
    }
}
