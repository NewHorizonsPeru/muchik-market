using bcriptNet = BCrypt.Net.BCrypt;

namespace midis.muchik.market.crosscutting.bcrypt
{
    public static class BcryptManager
    {
        public static string Hash(string textToHash)
        {
            if (string.IsNullOrEmpty(textToHash)) return string.Empty;
            return bcriptNet.HashPassword(textToHash);
        }

        public static bool Verify(string text, string hash)
        {
            if (string.IsNullOrEmpty(text)) return false;
            if (string.IsNullOrEmpty(hash)) return false;

            return bcriptNet.Verify(text, hash);
        }
    }
}
