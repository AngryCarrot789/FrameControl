using System.Windows;
using System.Windows.Input;
using FrameControl.Core.Dialogs;
using FrameControl.Windows;
using REghZy.MVVM.Commands;

namespace FrameControl.Dialogs {
    public class DialogBase : WindowBase {
        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public DialogBase() {
            this.ConfirmCommand = new RelayCommand(ConfirmAction);
            this.CancelCommand = new RelayCommand(CancelAction);
        }

        public virtual void ConfirmAction() {
            this.DialogResult = true;
            CloseDialogGeneral();
        }

        public virtual void CancelAction() {
            this.DialogResult = false;
            CloseDialogGeneral();
        }

        public virtual void CloseDialogGeneral() {
            Close();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e) {
            base.OnPreviewKeyDown(e);
            if (e.Key == Key.Escape) {
                CancelAction();
            }
            else if (e.Key == Key.Enter) {
                ConfirmAction();
            }
        }

        /// <summary>
        /// Sets this dialog's data context, shows the window as a dialog, and returns whether the dialog was accepted or not
        /// </summary>
        /// <param name="model"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool ShowDialogSafe<T>(T model) where T : BaseDialogViewModel {
            return Application.Current.Dispatcher.Invoke(() => {
                this.DataContext = model;
                return ShowDialog() == true;
            });
        }
    }
}