using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace HeikinAshiChart
{
    public class ViewModel
    {
        public ObservableCollection<CandleData> StockData { get; set; }

        public ViewModel()
        {
            StockData = [];
            ReadCSV("HeikinAshiChart.Resources.stockmsft.csv");
        }

        private void ReadCSV(string resourceStream)
        {
            Assembly executingAssembly = typeof(App).GetTypeInfo().Assembly;
            Stream? inputStream = executingAssembly.GetManifestResourceStream(resourceStream);

            string? line;
            List<string> lines = [];

            if (inputStream != null)
            {
                using StreamReader reader = new(inputStream);

                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }

                lines.RemoveAt(0);
                lines.Reverse();

                foreach (var dataPoint in lines)
                {
                    string[] data = dataPoint.Split(',');

                    //To get the date data
                    DateTime date = DateTime.ParseExact(data[0], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    var open = Convert.ToDouble(data[1].Trim('"'));
                    var high = Convert.ToDouble(data[2].Trim('"'));
                    var low = Convert.ToDouble(data[3].Trim('"'));
                    var close = Convert.ToDouble(data[4].Trim('"'));
                    StockData.Add(new CandleData(date, open, high, low, close));
                }
            }
        }
    }
}
