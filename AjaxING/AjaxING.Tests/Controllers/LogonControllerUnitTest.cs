using AjaxING.Controllers;
using AjaxING.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AjaxING.Tests.Controllers
{
    [TestClass]
    public class LogonControllerUnitTest
    {
        [TestMethod]
        public void LoginUserGet()
        {
            // Arrange  
            var controller = ArrangeMockServiceCall();
            var userID = "testuser456";
            var password = "123";

            // Act  
            var clientresponse = controller.LoginUser(userID, password);

            // Assert 
            Assert.IsNotNull(clientresponse.ToString());
        }

        /// <summary>
        /// Helper method
        /// </summary>
        /// <returns>WeatherController</returns>
        private static LogonController ArrangeMockServiceCall()
        {
            Mock<ILogonRepository> _mock = new Mock<ILogonRepository>();
            _mock.Setup(x => x.LoginUser(It.IsAny<string>(), It.IsAny<string>())).Returns(new Models.Product.LoginData());

            var controller = new LogonController(_mock.Object);
            return controller;
        }
    }
}
