#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - KillInfo.cs
// CREATED:       11/03/2019 (20:17)
// MODIFIED:      11/03/2019 (21:45)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using System.Globalization;
using CsvHelper.Configuration.Attributes;
using KovaaksAimTrainerCSVReader.Settings;

namespace KovaaksAimTrainerCSVReader.Models.Parsing{
    public class KillInfo{
        [Name("Kill #")]
        public int Id{ get; set; }

        [Name("Timestamp")]
        public string TimeStampRaw{ get; set; }

        public TimeSpan TimeStamp{
            get{
                if (!DateTime.TryParseExact(TimeStampRaw, Config.KillTimeStampFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt)){
                    throw new Exception($"Cannot read timestamp ({TimeStampRaw}) with format {Config.KillTimeStampFormat}");
                }

                return dt.TimeOfDay;
            }
        }

        [Name("Bot")]
        public string BotName{ get; set; }

        [Name("Weapon")]
        public string Weapon{ get; set; }

        [Name("TTK")]
        public string TimeToKillRaw{ get; set; }

        public TimeSpan TimeToKill{
            get{
                if (!DateTime.TryParseExact(TimeToKillRaw, Config.KillTimeToKillFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                {
                    throw new Exception($"Cannot read timestamp ({TimeToKillRaw}) with format {Config.KillTimeToKillFormat}");
                }

                return dt.TimeOfDay;
            }
        }

        [Name("Shots")]
        public int Shots{ get; set; }

        [Name("Hits")]
        public int Hits{ get; set; }

        [Name("Accuracy")]
        public float Accuracy { get; set; }

        [Name("Damage Done")]
        public float Damage { get; set; }

        [Name("Damage Possible")]
        public float MaxDamage { get; set; }

        [Name("Efficiency")]
        public float Efficiency { get; set; }

        [Name("Cheated")]
        public bool Cheated{ get; set; }
    }
}