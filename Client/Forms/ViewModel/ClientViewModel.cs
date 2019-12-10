using Common.MVVM;
using System;

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

        /// <summary>ボタン操作許可</summary>
        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set
            {
                _IsEnabled = value;
                CallPropertyChanged();
            }
        }

        /// <summary>通信エラーメッセージ</summary>
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set
            {
                _ErrorMessage = value;
                CallPropertyChanged();
            }
        }

        #endregion

        /// <summary>ボタン操作許可</summary>
        private bool _IsEnabled = true;

        /// <summary>通信エラーメッセージ</summary>
        private string _ErrorMessage = "";

        /// <summary>クライアント.ViewModel</summary>
        public ClientViewModel()
        {

            _Model = new Model.ClientModel();

            ExecuteCommand = new DelegateCommand(
                async () => 
                {

                    IsEnabled = false;
                    ErrorMessage = "";

                    try
                    {

                        // プロセス間通信でサーバに指示を出し、結果を受け取る
                        Result = await _Model.ExecuteServerSideAsync();
                        CallPropertyChanged(nameof(Result));

                    }
                    catch
                    {
                        ErrorMessage = "通信エラー発生";
                    }
                    finally
                    {
                        IsEnabled = true;
                    }

                },
                () => true);

        }

    }

}
