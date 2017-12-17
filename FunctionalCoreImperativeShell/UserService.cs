using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalCoreImperativeShell
{
    public class UserService
    {
        private readonly IUserRepository _users;

        public UserService(IUserRepository userRepository)
        {
            _users = userRepository;
        }

        public void SetAsAdministrator(Guid userId)
        {
            var user = _users
                .By(userId)
                .PromoteToAdministrator();

            _users.Save(user);
        }
    }
}
