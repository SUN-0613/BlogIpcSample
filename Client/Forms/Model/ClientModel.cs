using Common.IPC;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Client.Forms.Model
{

    /// <summary>クライアント.Model</summary>
    public class ClientModel
    {

        /// <summary>サーバ実行処理</summary>
        private IProcess _Server;

        /// <summary>クライアント.Model</summary>
        public ClientModel()
        {

            _Server = new ChannelFactory<IProcess>(
                new NetNamedPipeBinding(),
                new EndpointAddress(Service.GetAddress())
                ).CreateChannel();

        }

        /// <summary>プロセス間通信実行</summary>
        public async Task<int> ExecuteServerSideAsync()
        {
            return await _Server.ExecuteAsync(5);
        }

    }

}
