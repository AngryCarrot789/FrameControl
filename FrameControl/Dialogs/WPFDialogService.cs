using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrameControl.Core.Dialogs;
using FrameControl.Core.Dialogs.Message;
using FrameControl.Dialogs.Message;

namespace FrameControl.Dialogs {
    public class WPFDialogService : IDialogService {
        private readonly Dictionary<Type, Type> modelToWindowMap;

        public WPFDialogService() {
            this.modelToWindowMap = new Dictionary<Type, Type>();

            RegisterDialog<MessageDialogViewModel, MessageDialog>();
        }

        private void RegisterDialog<TViewModel, TWindow>() where TViewModel : BaseDialogViewModel where TWindow : DialogBase {
            this.modelToWindowMap[typeof(TViewModel)] = typeof(TWindow);
        }

        public bool ShowDialog<T>(T input) where T : BaseDialogViewModel {
            if (this.modelToWindowMap.TryGetValue(typeof(T), out Type windowType)) {
                DialogBase dialog = (DialogBase) Activator.CreateInstance(windowType);
                return dialog.ShowDialogSafe(input);
            }
            else {
                throw new Exception("No UI window registered for dialog view model: " + typeof(T));
            }
        }

        public bool ShowDialog<T>(out T output) where T : BaseDialogViewModel, new() {
            if (ShowDialog(output = new T())) {
                return true;
            }
            else {
                output = null;
                return false;
            }
        }

        public bool ShowDialog<T>(in T input, out T output) where T : BaseDialogViewModel, new() {
            if (ShowDialog(input)) {
                output = input;
                return true;
            }
            else {
                output = null;
                return false;
            }
        }

        public Task<bool> ShowDialogAsync<T>(T input) where T : BaseDialogViewModel {
            if (this.modelToWindowMap.TryGetValue(typeof(T), out Type windowType)) {
                DialogBase dialog = (DialogBase) Activator.CreateInstance(windowType);
                return Task.Run(() => dialog.ShowDialogSafe(input));
            }
            else {
                throw new Exception("No UI window registered for dialog view model: " + typeof(T));
            }
        }
    }
}