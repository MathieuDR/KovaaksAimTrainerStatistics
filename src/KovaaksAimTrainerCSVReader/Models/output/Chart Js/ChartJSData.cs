#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartJSData.cs
// CREATED:       14/03/2019 (19:50)
// MODIFIED:      14/03/2019 (19:50)
// MODIFIED BY:    (Mathieu)
#endregion

using System.Collections.Generic;
using Newtonsoft.Json;

namespace KovaaksAimTrainerCSVReader.Models.output.Chart_Js{
    public class ChartJSData{
        public ChartJSData(List<Session> sessions){
            Sessions = sessions;
            Graphs = new List<ChartJS>();
        }
        [JsonProperty("raw")]
        public List<Session> Sessions{ get; set; }
        [JsonProperty("graphs")]
        public List<ChartJS> Graphs{ get; set; }
    }
}