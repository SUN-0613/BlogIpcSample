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

        /// <summary>サーバ.ViewModel</summary>
        public ServerViewModel()
        {
            _Model = new Model.ServerModel();
        }

    }

}
