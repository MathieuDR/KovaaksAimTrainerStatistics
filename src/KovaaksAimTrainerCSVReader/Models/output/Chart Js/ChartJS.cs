#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartJS.cs
// CREATED:       14/03/2019 (19:50)
// MODIFIED:      14/03/2019 (19:50)
// MODIFIED BY:    (Mathieu)
#endregion

using System.Collections.Generic;
using KovaaksAimTrainerCSVReader.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KovaaksAimTrainerCSVReader.Models.output.Chart_Js{
    public abstract class ChartJS { }
    public class ChartJS<T> : ChartJS where T : struct
    {
        public ChartJS(string title, List<string> labels){
            ChartData = new ChartData<T>(labels);
            Title = title;
        }
        [JsonProperty("title")]
        public string Title{ get; set; }

        [JsonProperty("chart")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ChartType ChartType{ get; set; }

        [JsonProperty("data")]
        public ChartData<T> ChartData { get; set; }

        public void AddDataSet(string label, List<T?> data){
            ChartDataSet<T> chartdata = new ChartDataSet<T>(label, data);
            ChartData.ChartDataSets.Add(chartdata);
        }
    }
}