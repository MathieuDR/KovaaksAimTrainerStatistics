#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartDataSet.cs
// CREATED:       // ()
// MODIFIED:      14/03/2019 (19:55)
// MODIFIED BY:    (Mathieu)
#endregion

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KovaaksAimTrainerCSVReader.Models.output.Chart_Js{
    public class ChartDataSet<T> where T : struct
    {
        public ChartDataSet(string label, List<Metadata<T>> data){
            Label = label;
            Data = data;
        }

        public ChartDataSet(string label, List<T?> data){
            Label = label;
            Data = data.ToMetaDataList();
        }

        [JsonProperty("label")]
        public string Label{ get;  }
        [JsonProperty("data")]
        public List<Metadata<T>> Data{ get; }
    }
}