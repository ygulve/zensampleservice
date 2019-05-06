using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenDerivco.Models;

namespace ZenDerivco.Models.Repository
{
  public interface IAuthRepository
    {
        Employee Login(string userId, string password);
        bool UserExists(string userId);
    }
}
