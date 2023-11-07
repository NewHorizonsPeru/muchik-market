namespace midis.muchik.market.crosscutting.interfaces
{
    public interface IJwtManger
    {
        string GenerateToken(string userId, string email, string role);
    }
}
