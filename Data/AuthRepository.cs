using System.Linq;
using ZenDerivco.Models;
using ZenDerivco.Models.Repository;

namespace ZenDerivco.Data
{
    public class AuthRepository : IAuthRepository
    {

        readonly ZenDerivcoContext _context;
        public AuthRepository(ZenDerivcoContext context)
        {
            _context = context;
        }

        public Employee Login(string userId, string password)
        {
            return _context.Employees.FirstOrDefault(x => x.UserId == userId && x.Password == password);
        }

        public bool UserExists(string userId)
        {
            return false;
        }
    }
}
