#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - Session.cs
// CREATED:       12/03/2019 (19:42)
// MODIFIED:      12/03/2019 (19:42)
// MODIFIED BY:    (Mathieu)
#endregion

using System;
using KovaaksAimTrainerCSVReader.Models.Enum;

namespace KovaaksAimTrainerCSVReader.Models{
    public class Session{
        public SessionType sessionType{ get; set; } 
        public double Score{ get; set; }
        public string Name{ get; set; }
        public double Accuracy{ get; set; }
        public DateTime TimeStamp{ get; set; }
        public TimeSpan Duration{ get; set; }
        public bool ShouldCountStats{ get; set; }
    }
}