#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - Map.cs
// CREATED:       11/03/2019 (20:18)
// MODIFIED:      11/03/2019 (21:08)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using KovaaksAimTrainerCSVReader.Settings;

namespace KovaaksAimTrainerCSVReader.Models.Parsing{
    public class Map{
        public string Name{ get; set; }
        public TimeSpan Duration{ get; set; }
        public DateTime Timestamp{ get; set; }
        public List<KillInfo> KillInfos{ get; set; }
        public List<WeaponInfo> WeaponInfos{ get; set; }
        public SummaryInfo SummaryInfo{ get; set; }
        public SettingInfo SettingInfo{ get; set; }
        public bool IsChallenge{ get; set; }

        public void FinalizeParsing(string fileName){
            Duration = SummaryInfo.FightTime;
            Name = SummaryInfo.Scenario;

            // Parse Datetime from filename
            var dateTimeString = fileName.Split(Config.BeforeTimeStamp, StringSplitOptions.RemoveEmptyEntries).Last().Split(Config.AfterTimeStamp, StringSplitOptions.RemoveEmptyEntries).First();
            Timestamp = DateTime.ParseExact(dateTimeString, Config.FileDateTimeFormat, CultureInfo.InvariantCulture);

            // Check if it's a challenge
            IsChallenge = fileName.Contains(Config.ChallengeFileName);
        }
    }
}