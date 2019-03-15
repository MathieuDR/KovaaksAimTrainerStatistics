#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - SettingInfo.cs
// CREATED:       11/03/2019 (20:18)
// MODIFIED:      11/03/2019 (20:18)
// MODIFIED BY:    (Mathieu)
#endregion

namespace KovaaksAimTrainerCSVReader.Models{
    public class SettingInfo{
        public int InputLag{ get; set; }
        public double MaxFPS{ get; set; }
        public string SensScale{ get; set; }
        public double HorizontalSens{ get; set; }
        public double VerticalSens{ get; set; }
        public double FieldOfView{ get; set; }
        public bool HideGun{ get; set; }
        public string Crosshair{ get; set; }
        public double CrosshairScale{ get; set; }
        public string CrosshairColor{ get; set; }
    }
}