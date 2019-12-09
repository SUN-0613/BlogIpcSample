using Common.MVVM;

namespace Client.Forms.ViewModel
{

    /// <summary>クライアント.ViewModel</summary>
    public class ClientViewModel : ViewModelBase
    {

        #region Model

        /// <summary>クライアント.Model</summary>
        private Model.ClientModel _Model;

        #endregion

        #region Property

        /// <summary>実行コマンド</summary>
        public DelegateCommand ExecuteCommand { get; private set; }

        /// <summary>サーバ側処理の実行結果</summary>
        public int Result { get; private set; }

        #endregion

        /// <summary>クライアント.ViewModel</summary>
        public ClientViewModel()
        {

            _Model = new Model.ClientModel();

            ExecuteCommand = new DelegateCommand(
                async () => 
                {

                    // プロセス間通信でサーバに指示を出し、結果を受け取る
                    Result = await _Model.ExecuteServerSideAsync();
                    CallPropertyChanged(nameof(Result));

                },
                () => true);

        }

    }

}
