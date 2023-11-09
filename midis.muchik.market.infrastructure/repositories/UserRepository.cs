using Microsoft.EntityFrameworkCore;
using midis.muchik.market.domain.entities;
using midis.muchik.market.domain.interfaces;
using midis.muchik.market.infrastructure.context;

namespace midis.muchik.market.infrastructure.repositories
{
    public class UserRepository : GenericRepository<SecurityContext, User>, IUserRepository
    {
        public UserRepository(SecurityContext context) : base(context) { }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.Include(w => w.Role).Where(w => w.Email.Equals(email)).ToList().FirstOrDefault();
        }
    }
}
