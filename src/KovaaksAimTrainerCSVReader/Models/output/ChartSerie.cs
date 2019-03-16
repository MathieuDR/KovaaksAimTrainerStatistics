#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartSerie.cs
// CREATED:       15/03/2019 (23:22)
// MODIFIED:      16/03/2019 (14:11)
// MODIFIED BY:    (Mathieu)

#endregion

using System.Collections.Generic;

namespace KovaaksAimTrainerCSVReader.Models.output{
    public class ChartSerie{

        public ChartSerie(string title, List<ChartData> data, Dictionary<string, string> options = null){
            Title = title;
            Data = data;
            SerieOptions = options ?? new Dictionary<string, string>();

        }

        public string Title{ get; set; }
        public List<ChartData> Data{ get; set; }
        public Dictionary<string, string> SerieOptions{ get; set; }
    }
}