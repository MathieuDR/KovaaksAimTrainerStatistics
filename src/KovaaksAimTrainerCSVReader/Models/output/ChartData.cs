#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartData.cs
// CREATED:       // ()
// MODIFIED:      14/03/2019 (19:55)
// MODIFIED BY:    (Mathieu)
#endregion

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KovaaksAimTrainerCSVReader.Models.output{
    public class ChartData{
        public ChartData(List<String> labels){
            Labels = labels;
            ChartDataSets = new List<ChartDataSet>();
        }

        [JsonProperty("labels")]
        public List<String> Labels{ get; }

        [JsonProperty("datasets")]
        public List<ChartDataSet> ChartDataSets{ get; }
    }
}