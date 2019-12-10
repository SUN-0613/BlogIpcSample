using Common.MVVM;

namespace Server.Forms.ViewModel
{

    /// <summary>サーバ.ViewModel</summary>
    public class ServerViewModel : ViewModelBase
    {

        #region Model

        /// <summary>サーバ.Model</summary>
        private Model.ServerModel _Model;

        #endregion

        #region Property

        /// <summary>現在値</summary>
        public int PresentValue { get; set; }

        /// <summary>通信コマンド</summary>
        public DelegateCommand<string> ConnectCommand { get; private set; }

        /// <summary>ボタン操作許可</summary>
        public bool IsButtonEnabled { get; set; } = true;

        /// <summary>開始ボタン操作許可</summary>
        public bool IsOpenEnabled { get; set; } = true;

        /// <summary>切断ボタン操作許可</summary>
        public bool IsCloseEnabled { get; set; } = false;

        #endregion

        /// <summary>サーバ.ViewModel</summary>
        public ServerViewModel()
        {

            _Model = new Model.ServerModel(UpdateProperty, UpdateButtonEnabled);

            ConnectCommand = new DelegateCommand<string>(
                (parameter) => 
                {

                    switch (parameter)
                    {

                        case "open":
                            _Model.Open();
                            UpdateConnectEnabled(true);
                            break;

                        case "close":
                            _Model.Close();
                            UpdateConnectEnabled(false);
                            break;

                    }

                },
                () => true);

        }

        /// <summary>プロパティ更新</summary>
        /// <param name="value">更新値</param>
        private void UpdateProperty(int value)
        {

            PresentValue = value;
            CallPropertyChanged(nameof(PresentValue));

        }

        /// <summary>通信許可プロパティ更新</summary>
        /// <param name="value">
        /// true :通信開始
        /// false:通信終了
        /// </param>
        private void UpdateConnectEnabled(bool value)
        {

            IsOpenEnabled = !value;
            CallPropertyChanged(nameof(IsOpenEnabled));

            IsCloseEnabled = value;
            CallPropertyChanged(nameof(IsCloseEnabled));

        }

        /// <summary>ボタン操作許可プロパティ更新</summary>
        /// <param name="value">更新値</param>
        private void UpdateButtonEnabled(bool value)
        {
            IsButtonEnabled = value;
            CallPropertyChanged(nameof(IsButtonEnabled));
        }

    }

}
