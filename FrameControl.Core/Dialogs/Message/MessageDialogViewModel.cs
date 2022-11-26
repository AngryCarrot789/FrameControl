namespace FrameControl.Core.Dialogs.Message {
    public class MessageDialogViewModel : BaseDialogViewModel {
        private string caption;
        public string Caption {
            get => this.caption;
            set => RaisePropertyChanged(ref this.caption, value);
        }

        private string text;
        public string Text {
            get => this.text;
            set => RaisePropertyChanged(ref this.text, value);
        }
    }
}