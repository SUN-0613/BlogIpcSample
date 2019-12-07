using Common.Properties;

namespace Common.IPC
{

    /// <summary>IPC通信にて使用するメソッド用クラス</summary>
    public static class Service
    {

        /// <summary>アドレス取得</summary>
        public static string GetAddress()
        {
            return Resources.BaseAddress + "/" + Resources.Endpoint;
        }

        /// <summary>ベースアドレス取得</summary>
        public static string GetBaseAddress()
        {
            return Resources.BaseAddress;
        }

        /// <summary>エンドポイント取得</summary>
        public static string GetEndpoint()
        {
            return Resources.Endpoint;
        }

    }

}
