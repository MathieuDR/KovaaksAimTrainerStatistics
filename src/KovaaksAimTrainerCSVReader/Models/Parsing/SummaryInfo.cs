#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - SummaryInfo.cs
// CREATED:       11/03/2019 (20:17)
// MODIFIED:      11/03/2019 (20:17)
// MODIFIED BY:    (Mathieu)
#endregion

using System;

namespace KovaaksAimTrainerCSVReader.Models.Parsing{
    public class SummaryInfo{
        public int Kills{ get; set; }
        public int Deaths{ get; set; }
        public TimeSpan FightTime{ get; set; }
        public double AverageTimeToKill{ get; set; }
        public double DamageDone{ get; set; }
        public double DamageTaken{ get; set; }
        public int MidAirs{ get; set; }
        public int MidAired{ get; set; }
        public int Directs{ get; set; }
        public int Directed{ get; set; }
        public double DistanceTraveled{ get; set; }
        public double Score{ get; set; }
        public string Scenario{ get; set; }
        public string Hash{ get; set; }
        public string GameVersion{ get; set; }
    }
}