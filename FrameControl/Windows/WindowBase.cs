using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace FrameControl.Windows {
    public class WindowBase : Window {
        public static readonly DependencyProperty TitlebarColourProperty =
            DependencyProperty.Register(
                "TitlebarColour",
                typeof(Brush),
                typeof(WindowBase),
                new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Gray)));

        [Category("Brush")]
        public Brush TitlebarColour {
            get => (Brush) GetValue(TitlebarColourProperty);
            set => SetValue(TitlebarColourProperty, value);
        }

        public WindowBase() {
            
        }
    }
}