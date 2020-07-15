using System.Windows;
using System.Windows.Input;

namespace SimplePaint
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 2nd ディスプレイがあればそっちに表示する
            foreach (var scr in System.Windows.Forms.Screen.AllScreens)
            {
                if (!scr.Primary)
                {
                    this.Left = scr.Bounds.Left;
                    this.Top = scr.Bounds.Top;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }
    }
}
