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

        /// <summary>切断コマンド</summary>
        public DelegateCommand CloseCommand { get; private set; }

        /// <summary>ボタン操作許可</summary>
        public bool IsEnabled { get; set; } = true;

        #endregion

        /// <summary>サーバ.ViewModel</summary>
        public ServerViewModel()
        {

            _Model = new Model.ServerModel(UpdateProperty, UpdateEnabled);

            CloseCommand = new DelegateCommand(
                () => 
                {
                    _Model?.Dispose();
                    UpdateEnabled(false);
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

        /// <summary>ボタン操作許可プロパティ更新</summary>
        /// <param name="value">更新値</param>
        private void UpdateEnabled(bool value)
        {
            IsEnabled = value;
            CallPropertyChanged(nameof(IsEnabled));
        }

    }

}
