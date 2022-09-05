namespace ExchangeWebApi
{
    public interface IJwtTokenManager
    {
        string Authenticate(string userName,string password);
    }
}
