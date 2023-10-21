using MiniULTHack.Models;
using Renci.SshNet;

namespace MiniULTHack.Services.Login
{
    public class SshLoginService : IConnectionService
    {

        public const string LogFile = "../ult2/mini-ult.log";

        public SshClient Client { get; private set; }

        public List<FridgeModel> GetFridgeSerialNumbers()
        {
            throw new NotImplementedException();
        }

        public string GetLogRaw()
        {
            if (Client == null) { return null; }

            using (SshCommand command = Client.CreateCommand("cat " + LogFile + ";"))
            {
                command.Execute();
                return command.Result;
            }
        }

        public bool Login(string ip, string username, string password)
        {
            Client = new SshClient(ip, username, password);

            try
            {
                Client.Connect();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
