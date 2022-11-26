namespace FrameControl.Core.Dialogs {
    public class ConnectionDialogViewModel : BaseDialogViewModel {
        private string address;
        public string Address {
            get => this.address;
            set => RaisePropertyChanged(ref this.address, value);
        }

        private int port;
        public int Port {
            get => this.port;
            set => RaisePropertyChanged(ref this.port, value);
        }

        public ConnectionDialogViewModel() {

        }
    }
}