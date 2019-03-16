#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartJSChartData.cs
// CREATED:       15/03/2019 (23:18)
// MODIFIED:      16/03/2019 (01:09)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KovaaksAimTrainerCSVReader.Models.output.Chart_Js{
    public class ChartJsChartData{
        public ChartJsChartData(List<String> labels){
            Labels = labels;
            ChartDataSets = new List<ChartJsDataSet>();
        }

        [JsonProperty("labels")]
        public List<String> Labels{ get; }

        [JsonProperty("datasets")]
        public List<ChartJsDataSet> ChartDataSets{ get; }
    }
}