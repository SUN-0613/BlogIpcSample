using Common.IPC;
using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Forms.Model
{

    /// <summary>サーバ.Model</summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServerModel : IProcess, IDisposable
    {

        /// <summary>プロパティ更新デリゲート</summary>
        /// <param name="value">表示データ</param>
        public delegate void UpdatePropertyDelegate(int value);

        /// <summary>IPC通信サービス</summary>
        private ServiceHost _Host;

        /// <summary>プロパティ更新メソッド</summary>
        private UpdatePropertyDelegate _UpdateProperty;

        /// <summary>サーバModel</summary>
        /// <param name="updateProperty">プロパティ更新メソッド</param>
        public ServerModel(UpdatePropertyDelegate updateProperty)
        {

            _UpdateProperty = updateProperty;

            // IPC通信サービス開始
            _Host = new ServiceHost(this, new Uri(Service.GetBaseAddress()));
            _Host.AddServiceEndpoint(typeof(IProcess), new NetNamedPipeBinding(), Service.GetEndpoint());
            _Host.Open();

        }

        /// <summary>解放処理</summary>
        public void Dispose()
        {

            _UpdateProperty = null;

            // IPC通信サービス終了
            _Host.Close();

        }

        /// <summary>IPC通信処理実行</summary>
        /// <param name="sec">処理秒数</param>
        Task<int> IProcess.ExecuteAsync(int sec)
        {

            var value = -1;
            var random = new Random();

            return Task.Run(() => 
            {

                // 何か重たい処理
                for (var i = 0; i < sec; i++)
                {

                    Thread.Sleep(1000);
                    value = random.Next();

                    // ViewModelのプロパティ更新
                    _UpdateProperty(value);

                }

                return value;

            });

        }

    }

}
