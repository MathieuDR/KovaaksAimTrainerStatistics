#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartSerie.cs
// CREATED:       // ()
// MODIFIED:      15/03/2019 (23:22)
// MODIFIED BY:    (Mathieu)
#endregion

using System;
using System.Collections.Generic;

namespace KovaaksAimTrainerCSVReader.Models.output{
    public class ChartSerie<T>  where T: struct{
        public string Title{ get; set; }
        public List<ChartData<T>> Data{ get; set; }
        public Dictionary<string, string> SerieOptions { get; set; }
    }
}