#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - Graph.cs
// CREATED:       14/03/2019 (19:50)
// MODIFIED:      14/03/2019 (19:50)
// MODIFIED BY:    (Mathieu)
#endregion

using System.Collections.Generic;
using KovaaksAimTrainerCSVReader.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KovaaksAimTrainerCSVReader.Models.output{
    public class Graph{
        public Graph(string title, List<string> labels){
            ChartData = new ChartData(labels);
            Title = title;
        }
        [JsonProperty("title")]
        public string Title{ get; set; }

        [JsonProperty("chart")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ChartType ChartType{ get; set; }

        [JsonProperty("data")]
        public ChartData ChartData{ get; set; }
    }
}