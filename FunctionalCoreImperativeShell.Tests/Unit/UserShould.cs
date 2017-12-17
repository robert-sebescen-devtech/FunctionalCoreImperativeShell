using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace FunctionalCoreImperativeShell.Tests
{
    [TestClass]
    public class UserShould
    {
        [TestMethod]
        public void SuccessfullyChangeUsername()
        {
            var user = NewUser();

            user.ChangeUsername("NewUsername").Username.Should().Be("NewUsername");
            user.Username.Should().Be("Initial");
        }

        [TestMethod]
        public void SuccessfullyChangeUserType()
        {
            var user = NewUser(UserType.Basic);

            user.PromoteToAdministrator().Type.Should().Be(UserType.Administrator);
            user.Type.Should().Be(UserType.Basic);
        }

        [TestMethod]
        public void NotAllowPromotingGuestUserToAnAdministrator()
        {
            var user = NewUser(UserType.Guest);

            Action promoteUserToAdministrator = () => user.PromoteToAdministrator();

            promoteUserToAdministrator.ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void IgnorePromotingExistingAdministratorToAnAdministrator()
        {
            var user = NewUser(UserType.Administrator);

            user.PromoteToAdministrator().Should().BeSameAs(user);
        }

        private User NewUser(UserType type = UserType.Guest)
        {
            return new User(Guid.NewGuid(), "Initial", "FN", "LN", type);
        }
    }
}
