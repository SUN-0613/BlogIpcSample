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

        #endregion

        /// <summary>サーバ.ViewModel</summary>
        public ServerViewModel()
        {

            _Model = new Model.ServerModel(UpdateProperty);

            CloseCommand = new DelegateCommand(
                () => 
                {
                    _Model?.Dispose();
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

    }

}
