using Syncfusion.UI.Xaml.Charts;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

namespace HeikinAshiChart
{
    public class HeikinAshiSeries : CandleSeries
    {
        private ObservableCollection<CandleData> _previousCollection;

        public HeikinAshiSeries()
        {
            _previousCollection = [];
        }

        public static readonly DependencyProperty HeikinAshiItemsSourceProperty =
            DependencyProperty.Register(
                nameof(HeikinAshiItemsSource),
                typeof(ObservableCollection<CandleData>),
                typeof(HeikinAshiSeries),
                new PropertyMetadata(null, OnHeikinAshiItemsSourceChanged));

        private static void OnHeikinAshiItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is HeikinAshiSeries series)
            {
                if (e.OldValue is ObservableCollection<CandleData> oldCollection)
                {
                    series.UnbindNotifications(oldCollection);
                }

                if (e.NewValue is ObservableCollection<CandleData> newCollection)
                {
                    series.CalculateHeikinAshi(newCollection);
                    series.BindNotifications(newCollection);
                }
            }
        }

        private void BindNotifications(ObservableCollection<CandleData> collection)
        {
            _previousCollection = collection;
            collection.CollectionChanged += HeikinAshiItemsSource_CollectionChanged; ;
        }

        private void HeikinAshiItemsSource_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<CandleData> newCollection)
            {
                CalculateHeikinAshi(newCollection);
            }
        }

        private void UnbindNotifications(ObservableCollection<CandleData> collection)
        {
            collection.CollectionChanged -= HeikinAshiItemsSource_CollectionChanged;

            if (_previousCollection == collection)
            {
                _previousCollection = null;
            }
        }

        public ObservableCollection<CandleData> HeikinAshiItemsSource
        {
            get { return (ObservableCollection<CandleData>)GetValue(HeikinAshiItemsSourceProperty); }
            set { SetValue(HeikinAshiItemsSourceProperty, value); }
        }

        private void CalculateHeikinAshi(ObservableCollection<CandleData> collection)
        {
            var heikinAshiData = new ObservableCollection<CandleData>();

            if (collection.Count == 0)
            {
                ItemsSource = heikinAshiData;
                return;
            }

            var firstCandle = collection[0];
            double prevClose = (firstCandle.Open + firstCandle.Close) / 2;
            double prevOpen = prevClose;

            foreach (var currentCandle in collection)
            {
                double open = (prevOpen + prevClose) / 2;
                double close = (currentCandle.Open + currentCandle.High + currentCandle.Low + currentCandle.Close) / 4;
                double high = Math.Max(currentCandle.High, Math.Max(open, close));
                double low = Math.Min(currentCandle.Low, Math.Min(open, close));

                heikinAshiData.Add(new CandleData { Date = currentCandle.Date, Open = open, High = high, Low = low, Close = close });
                prevClose = close;
                prevOpen = open;
            }

            ItemsSource = heikinAshiData;
        }
    }
}
