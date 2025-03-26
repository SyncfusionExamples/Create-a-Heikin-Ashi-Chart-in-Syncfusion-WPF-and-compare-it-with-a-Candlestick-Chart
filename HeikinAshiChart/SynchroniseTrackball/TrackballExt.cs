using Syncfusion.UI.Xaml.Charts;
using System.Windows;

namespace HeikinAshiChart
{
    public class TrackballExt : ChartTrackBallBehavior
    {
        public void ActivateTrackball(Point mousePoint)
        {
            IsActivated = true;
            OnPointerPositionChanged(mousePoint);
        }

        public void DeactivateTrackball()
        {
            IsActivated = false;
        }
    }
}
