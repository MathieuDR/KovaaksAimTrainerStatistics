#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - WeaponInfo.cs
// CREATED:       11/03/2019 (20:17)
// MODIFIED:      11/03/2019 (20:17)
// MODIFIED BY:    (Mathieu)
#endregion

using CsvHelper.Configuration.Attributes;

namespace KovaaksAimTrainerCSVReader.Models{
    public class WeaponInfo{
        [Name("Weapon")]
        public string Weapon{ get; set; }

        [Name("Shots")]
        public int Shots{ get; set; }

        [Name("Hits")]
        public int Hits{ get; set; }

        [Name("Damage Done")]
        public double Damage{ get; set; }

        [Name("Damage Possible")]
        public double MaxDamage{ get; set; }

        [Name("")]
        public string Misc{ get; set; } // There is an empty field?

        [Name("Sens Scale")]
        public string SensScale{ get; set; }

        [Name("Horiz Sens")]
        public string HorizontalSens{ get; set; }

        [Name("Vert Sens")]
        public string VerticalSens{ get; set; }

        [Name("FOV")]
        public string FieldOfView{ get; set; }

        [Name("Hide Gun")]
        public string HideGun{ get; set; }

        [Name("Crosshair")]
        public string Crosshair{ get; set; }

        [Name("Crosshair Scale")]
        public string CrosshairScale{ get; set; }

        [Name("Crosshair Color")]
        public string CrosshairColor{ get; set; }

        [Name("ADS Sens")]
        public string ADSSens{ get; set; }

        [Name("ADS Zoom Scale")]
        public string ADSZoomScale{ get; set; }
    }
}