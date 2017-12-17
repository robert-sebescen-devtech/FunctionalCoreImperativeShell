using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalCoreImperativeShell
{
    public interface IUserRepository
    {
        User By(Guid id);
        void Save(User user);
    }
}
