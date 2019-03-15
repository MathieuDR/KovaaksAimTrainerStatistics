#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - Data.cs
// CREATED:       14/03/2019 (19:50)
// MODIFIED:      14/03/2019 (19:50)
// MODIFIED BY:    (Mathieu)
#endregion

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KovaaksAimTrainerCSVReader.Models.output{
    public class Data{
        public Data(List<Session> sessions){
            Sessions = sessions;
            Graphs = new List<Graph>();
        }
        [JsonProperty("raw")]
        public List<Session> Sessions{ get; set; }
        [JsonProperty("graphs")]
        public List<Graph> Graphs{ get; set; }
    }
}