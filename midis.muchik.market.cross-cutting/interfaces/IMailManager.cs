namespace midis.muchik.market.crosscutting.interfaces
{
    public interface IMailManager
    {
        void SendMail(string pathMailing, string mailRecipients, Dictionary<string, string> valuesMailing);
    }
}
