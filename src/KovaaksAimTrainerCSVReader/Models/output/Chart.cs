#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - Chart.cs
// CREATED:       15/03/2019 (23:21)
// MODIFIED:      16/03/2019 (14:11)
// MODIFIED BY:    (Mathieu)

#endregion

using System.Collections.Generic;
using KovaaksAimTrainerCSVReader.Models.Enum;

namespace KovaaksAimTrainerCSVReader.Models.output{
    public class Chart{
        public string Title{ get; set; }
        public List<ChartSerie> Series{ get; set; }
        public Dictionary<string, string> ChartOptions{ get; set; }
        public ChartType ChartType{ get; set; }
    }
}