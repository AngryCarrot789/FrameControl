using System.Threading.Tasks;

namespace FrameControl.Core.Dialogs {
    public interface IDialogService {
        bool ShowDialog<T>(T input) where T : BaseDialogViewModel;
        
        bool ShowDialog<T>(out T output) where T : BaseDialogViewModel, new();

        bool ShowDialog<T>(in T input, out T output) where T : BaseDialogViewModel, new();

        Task<bool> ShowDialogAsync<T>(T input) where T : BaseDialogViewModel;
    }
}