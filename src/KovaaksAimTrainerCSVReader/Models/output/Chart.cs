#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - Chart.cs
// CREATED:       15/03/2019 (23:21)
// MODIFIED:      16/03/2019 (14:21)
// MODIFIED BY:    (Mathieu)

#endregion

using System.Collections.Generic;
using System.Linq;
using KovaaksAimTrainerCSVReader.Business.Helpers;
using KovaaksAimTrainerCSVReader.Models.Enum;
using KovaaksAimTrainerCSVReader.Models.output.Chart_Js;

namespace KovaaksAimTrainerCSVReader.Models.output{
    public class Chart{
        private readonly List<ChartSerie> _series;

        public Chart(ChartType chartType, string title, List<ChartSerie> series = null, Dictionary<string, string> options = null){
            Title = title;
            _series = series ?? new List<ChartSerie>();
            _chartOptions = options ?? new Dictionary<string, string>();
            ChartType = chartType;
        }

        public string Title{ get; set; }

        public IReadOnlyList<ChartSerie> Series{
            get{
                return _series.AsReadOnly();
            }
        }

        private Dictionary<string, string> _chartOptions{ get; }

        public IReadOnlyDictionary<string, string> ChartOptions{
            get{
                return (IReadOnlyDictionary<string, string>) _chartOptions;
            }
        }

        public ChartType ChartType{ get; }


        public void AddChartSerie(ChartSerie serie)
        {
            _series.Add(serie);
        }

        public void AddChartSerie<T>(string label, List<T?> data, Dictionary<string, string> options = null) where T : struct
        {
            ChartSerie chartData = new ChartSerie(label, data.ToMetaDataList<T>().Cast<ChartData>().ToList(), options);
            _series.Add(chartData);
        }

        public void AddChartSerie(string label, List<string> data, Dictionary<string, string> options = null)
        {
            ChartSerie chartData = new ChartSerie(label, data.ToMetaDataList().Cast<ChartData>().ToList(), options);
            _series.Add(chartData);
        }

        public void AddOption(string key, string value){
            _chartOptions.TryAdd(key, value);
        }
    }
}