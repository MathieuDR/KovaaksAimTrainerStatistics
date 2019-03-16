#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartJsDataSet.cs
// CREATED:       // ()
// MODIFIED:      14/03/2019 (19:55)
// MODIFIED BY:    (Mathieu)
#endregion

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KovaaksAimTrainerCSVReader.Models.output.Chart_Js{
    public class ChartJsDataSet
    {
        public ChartJsDataSet(string label, List<ChartData> data)
        {
            Label = label;
            Data = data;
        }
        
        [JsonProperty("label")]
        public string Label{ get;  }
        [JsonProperty("data")]
        public List<ChartData> Data{ get; }
    }
}