using FrameControl.Core.Dialogs;
using FrameControl.Core.Services;

namespace FrameControl.Core {
    public class IoC {
        public static IoC Instance { get; } = new IoC();

        public IDialogService DialogService => ServiceManager.Instance.Get<IDialogService>();

        private IoC() {

        }
    }
}