using Syncfusion.UI.Xaml.Charts;
using System.Windows;
using System.Windows.Input;

namespace HeikinAshiChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Point MousePoint { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void heikinAshiChart_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // Taking the first chart position as reference to get the mouse point.
            MousePoint = Mouse.GetPosition(trackball1.AdorningCanvas);

            if (sender is SfChart chart)
            {
                if (chart.SeriesClipRect.Contains(MousePoint))
                {
                    // Generalizing position with respect to axis width.
                    MousePoint = new Point(
                    MousePoint.X - chart.SeriesClipRect.Left,
                    MousePoint.Y - chart.SeriesClipRect.Top);

                    trackball1.ActivateTrackball(MousePoint);
                    trackball2.ActivateTrackball(MousePoint);
                }
                else
                {
                    trackball1.DeactivateTrackball();
                    trackball2.DeactivateTrackball();
                }
            }            
        }

        private void candleChart_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // Taking the first chart position as reference to get the mouse point.
            MousePoint = Mouse.GetPosition(trackball2.AdorningCanvas);

            if (sender is SfChart chart)
            {
                if (chart.SeriesClipRect.Contains(MousePoint))
                {
                    // Generalizing position with respect to axis width.
                    MousePoint = new Point(
                    MousePoint.X - chart.SeriesClipRect.Left,
                    MousePoint.Y - chart.SeriesClipRect.Top);

                    trackball1.ActivateTrackball(MousePoint);
                    trackball2.ActivateTrackball(MousePoint);
                }
                else
                {
                    trackball1.DeactivateTrackball();
                    trackball2.DeactivateTrackball();
                }
            }    
        }
    }
}