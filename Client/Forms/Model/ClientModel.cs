using Common.IPC;
using System.ServiceModel;

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
        public int ExecuteServerSide()
        {
            return _Server.Execute(5);
        }

    }

}
