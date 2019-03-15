#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - SummaryParser.cs
// CREATED:       12/03/2019 (23:28)
// MODIFIED:      12/03/2019 (23:34)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using KovaaksAimTrainerCSVReader.Models.Parsing;

namespace KovaaksAimTrainerCSVReader.Logic.Parsing{
    public class SummaryParser{
        public static SummaryInfo Parse(FileInfo file, string rawInfo){
            Console.WriteLine($"Reading Summary Info of {file.Name}");
            var result = new SummaryInfo();

            var lines = rawInfo.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines){
                var normalizedLines = line.ToLowerInvariant().Split(',', StringSplitOptions.RemoveEmptyEntries);
                switch (normalizedLines.First()){
                    case "kills:":
                        result.Kills = int.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "deaths:":
                        result.Deaths = int.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "fight time:":
                        //TODO
                        //result.FightTime = 
                        break;
                    case "avg ttk:":
                        //TODO
                        //result.FightTime = 
                        break;
                    case "damage done:":
                        result.DamageDone = double.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "damage taken:":
                        result.DamageTaken = double.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "midairs:":
                        result.MidAirs = int.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "midaired:":
                        result.MidAired = int.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "directs:":
                        result.Directs = int.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "directed:":
                        result.Directed = int.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "distance traveled:":
                        result.DistanceTraveled = double.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "score:":
                        result.Score = double.Parse(normalizedLines.Last(), CultureInfo.InvariantCulture);
                        break;
                    case "scenario:":
                        result.Scenario = normalizedLines.Last();
                        break;
                    case "hash:":
                        result.Hash = normalizedLines.Last();
                        break;
                    case "game version:":
                        result.GameVersion = normalizedLines.Last();
                        break;
                    default:
                        throw new Exception($"Unknown line in Summary info {line}. {normalizedLines}");
                }
            }

            return result;
        }
    }
}