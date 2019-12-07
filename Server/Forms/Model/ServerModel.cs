using Common.IPC;
using System;
using System.ServiceModel;
using System.Threading;

namespace Server.Forms.Model
{

    /// <summary>サーバ.Model</summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServerModel : IProcess, IDisposable
    {

        /// <summary>IPC通信サービス</summary>
        private ServiceHost _Host;

        /// <summary>サーバModel</summary>
        public ServerModel()
        {

            // IPC通信サービス開始
            _Host = new ServiceHost(this, new Uri(Service.GetBaseAddress()));
            _Host.AddServiceEndpoint(typeof(IProcess), new NetNamedPipeBinding(), Service.GetEndpoint());
            _Host.Open();

        }

        /// <summary>解放処理</summary>
        public void Dispose()
        {

            // IPC通信サービス終了
            _Host.Close();

        }

        /// <summary>IPC通信処理実行</summary>
        /// <param name="sec">処理秒数</param>
        int IProcess.Execute(int sec)
        {

            var value = -1;
            var random = new Random();

            // 何か重たい処理
            for (var i = 0; i < sec; i++)
            {

                Thread.Sleep(1000);
                value = random.Next();

            }

            return value;

        }

    }

}
