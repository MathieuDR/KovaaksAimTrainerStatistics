#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - SettingParser.cs
// CREATED:       12/03/2019 (23:28)
// MODIFIED:      15/03/2019 (18:51)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using KovaaksAimTrainerCSVReader.Models.Parsing;

namespace KovaaksAimTrainerCSVReader.Logic.Parsing{
    public class SettingParser{
        public static SettingInfo Parse(FileInfo file, string rawInfo){
            Console.WriteLine($"Reading Settings Info of {file.Name}");
            var result = new SettingInfo();

            var lines = rawInfo.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines){
                var normalizedLines = line.ToLowerInvariant().Split(',', StringSplitOptions.RemoveEmptyEntries);

                switch (normalizedLines.First()){
                    case "input lag:":
                        result.InputLag = int.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "max fps (config):":
                        result.MaxFPS = double.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "sens scale:":
                        result.SensScale = normalizedLines.Last();
                        break;
                    case "horiz sens:":
                        result.HorizontalSens = double.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "vert sens:":
                        result.VerticalSens = double.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "fov:":
                        result.FieldOfView = double.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "hide gun:":
                        result.HideGun = bool.Parse(normalizedLines.Last());
                        break;
                    case "crosshair:":
                        result.Crosshair = normalizedLines.Last();
                        break;
                    case "crosshair scale:":
                        result.CrosshairScale = double.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "crosshair color:":
                        result.CrosshairColor = normalizedLines.Last();
                        break;
                    default:
                        throw new Exception($"Unknown line in Summary info {line}. {normalizedLines}");
                }
            }


            return result;
        }
    }
}