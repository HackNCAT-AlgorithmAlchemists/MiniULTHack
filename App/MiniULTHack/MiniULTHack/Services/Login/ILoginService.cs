namespace MiniULTHack.Services
{
    public interface ILoginService
    {
        bool Login(string ip, string username, string password);
    }
}
