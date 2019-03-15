#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - Chart.cs
// CREATED:       15/03/2019 (23:21)
// MODIFIED:      15/03/2019 (23:21)
// MODIFIED BY:    (Mathieu)
#endregion

using System;
using System.Collections.Generic;
using KovaaksAimTrainerCSVReader.Models.Enum;

namespace KovaaksAimTrainerCSVReader.Models.output{
    public abstract class Chart { }

    public class Chart<T> : Chart where T : struct{
        public string Title{ get; set; }
        public List<ChartSerie<T>> Series{ get; set; }
        public Dictionary<string, string> ChartOptions{ get; set; }
        public ChartType ChartType{ get; set; }
    }
}