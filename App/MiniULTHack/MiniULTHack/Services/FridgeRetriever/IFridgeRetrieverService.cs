using MiniULTHack.Models;

namespace MiniULTHack.Services.FridgeRetriever
{
    public interface IFridgeRetrieverService
    {
        List<FridgeModel> GetFridgeSerialNumbers();
        string GetLogRaw();

    }
}
