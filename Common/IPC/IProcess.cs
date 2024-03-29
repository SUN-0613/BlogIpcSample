﻿using System.ServiceModel;
using System.Threading.Tasks;

namespace Common.IPC
{

    /// <summary>プロセス間通信インターフェース</summary>
    [ServiceContract]
    public interface IProcess
    {

        /// <summary>サーバー側でメソッドを実行し、戻り値をクライアントに渡す</summary>
        /// <param name="sec">処理秒数</param>
        [OperationContract]
        Task<int> ExecuteAsync(int sec);

    }

}
