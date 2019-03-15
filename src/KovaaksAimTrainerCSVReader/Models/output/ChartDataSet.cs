#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartDataSet.cs
// CREATED:       // ()
// MODIFIED:      14/03/2019 (19:55)
// MODIFIED BY:    (Mathieu)
#endregion

using System.Collections.Generic;
using Newtonsoft.Json;

namespace KovaaksAimTrainerCSVReader.Models.output{
    public class ChartDataSet{
        public ChartDataSet(string label, List<double?> data){
            Label = label;
            Data = data;
        }

        [JsonProperty("label")]
        public string Label{ get;  }
        [JsonProperty("data")]
        public List<double?> Data{ get; }
    }
}