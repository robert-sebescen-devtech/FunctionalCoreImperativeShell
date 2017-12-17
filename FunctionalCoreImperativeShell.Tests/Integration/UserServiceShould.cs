using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalCoreImperativeShell.Tests.Integration
{
    [TestClass]
    public class UserServiceShould
    {
        [TestMethod]
        public void PromoteExistingUserToAnAdministratorRole()
        {
            var userId = Guid.NewGuid();

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(repository => repository.By(userId)).Returns(new User(userId, null, null, null, UserType.Basic));

            var userService = new UserService(userRepository.Object);

            userService.SetAsAdministrator(userId);

            userRepository.Verify(repository => repository.By(userId), Times.Once);
            userRepository.Verify(repository => repository.Save(It.Is<User>(user => user.Id.Equals(userId) && user.Type.Equals(UserType.Administrator))), Times.Once);
        }
    }
}
