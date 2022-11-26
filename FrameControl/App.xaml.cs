using System.Windows;
using FrameControl.Core.Dialogs;
using FrameControl.Core.Services;
using FrameControl.Dialogs;

namespace FrameControl {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private void App_OnStartup(object sender, StartupEventArgs e) {
            ServiceManager.Instance.Set<IDialogService>(new WPFDialogService());

            this.MainWindow = new MainWindow();
            this.MainWindow.Show();
        }
    }
}
