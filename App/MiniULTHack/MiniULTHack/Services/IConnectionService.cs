using MiniULTHack.Services.FridgeRetriever;

namespace MiniULTHack.Services
{
    public interface IConnectionService : ILoginService, IFridgeRetrieverService
    {
        string testLs();
    }
}