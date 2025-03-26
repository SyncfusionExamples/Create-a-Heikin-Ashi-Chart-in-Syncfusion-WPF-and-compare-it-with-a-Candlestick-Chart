using System.ComponentModel;

namespace HeikinAshiChart
{
    public class CandleData : INotifyPropertyChanged
    {
        private DateTime date;
        private double open;
        private double high;
        private double low;
        private double close;

        public DateTime Date { get => date; set { date = value; NotifyPropertyChanged(nameof(Date)); } }
        public double Open { get => open; set { open = value; NotifyPropertyChanged(nameof(Open)); } }
        public double High { get => high; set { high = value; NotifyPropertyChanged(nameof(High)); } }
        public double Low { get => low; set { low = value; NotifyPropertyChanged(nameof(Low)); } }
        public double Close { get => close; set { close = value; NotifyPropertyChanged(nameof(Close)); } }

        public CandleData()
        {

        }
        public CandleData(DateTime date, double open, double high, double low, double close)
        {
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
