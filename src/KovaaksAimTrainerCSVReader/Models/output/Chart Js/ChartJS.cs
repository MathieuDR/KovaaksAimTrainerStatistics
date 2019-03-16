#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartJs.cs
// CREATED:       15/03/2019 (23:18)
// MODIFIED:      16/03/2019 (01:09)
// MODIFIED BY:    (Mathieu)

#endregion

using System.Collections.Generic;
using System.Linq;
using KovaaksAimTrainerCSVReader.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KovaaksAimTrainerCSVReader.Models.output.Chart_Js{
   
    public class ChartJs {
        public ChartJs(string title, List<string> labels){
            ChartJsChartData = new ChartJsChartData(labels);
            Title = title;
        }

        [JsonProperty("title")]
        public string Title{ get; set; }

        [JsonProperty("chart")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ChartType ChartType{ get; set; }

        [JsonProperty("data")]
        public ChartJsChartData ChartJsChartData{ get; set; }

        public void AddDataSet<T>(string label, List<T?> data) where T : struct
        {
            List<ChartData<T>> set = data.ToMetaDataList<T>();
            ChartJsDataSet chartData = new ChartJsDataSet(label, data.ToMetaDataList<T>().Cast<ChartData>().ToList());
            ChartJsChartData.ChartDataSets.Add(chartData);
        }

        public void AddDataSet(string label, List<string> data) 
        {
            ChartJsDataSet chartData = new ChartJsDataSet(label, data.ToMetaDataList().Cast<ChartData>().ToList());
            ChartJsChartData.ChartDataSets.Add(chartData);
        }
    }
}