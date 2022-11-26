using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using FrameControl.Core;
using FrameControl.Core.Dialogs;
using FrameControl.Core.Dialogs.Message;
using FrameControl.Dialogs;
using FrameControl.Dialogs.Connection;

namespace FrameControl {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            Bitmap bmp = new Bitmap("F:\\Pictures\\game screenshots\\218620_20210905233711_1.png");

            long start = DateTime.Now.Ticks;
            BitmapImage image = BitmapToImageSource(bmp); // 100ms for a 1080p png, sized 3mb~
            long diff = DateTime.Now.Ticks - start;

            MessageBox.Show($"Timedif: {new DateTime(diff).Millisecond}");

            this.ImageFrame.Source = image;
        }

        BitmapImage BitmapToImageSource(Bitmap bitmap) {
            using (MemoryStream memory = new MemoryStream()) {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp); // 50ms~ on average
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit(); // 40ms~

                return bitmapImage;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (IoC.Instance.DialogService.ShowDialog(new MessageDialogViewModel() {Caption = "caption!", Text = "Text!!!"})) {
                MessageBox.Show($"You clicked confirm");
            }
            else {
                MessageBox.Show($"You clicked cancel");
            }
        }
    }
}
