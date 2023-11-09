using midis.muchik.market.domain.entities;

namespace midis.muchik.market.domain.interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User? GetUserByEmail(string email);
    }
}
