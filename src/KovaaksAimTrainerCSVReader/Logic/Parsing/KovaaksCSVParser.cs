#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - KovaaksCSVParser.cs
// CREATED:       12/03/2019 (23:28)
// MODIFIED:      12/03/2019 (23:39)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using KovaaksAimTrainerCSVReader.Logic.Transformers;
using KovaaksAimTrainerCSVReader.Models;
using KovaaksAimTrainerCSVReader.Settings;

namespace KovaaksAimTrainerCSVReader.Logic{
    public class KovaaksCSVParser{
        private readonly string _path;
        private readonly MapToSessionTransformer _transformer;

        public KovaaksCSVParser(string path){
            _path = path;
            _transformer = new MapToSessionTransformer();
        }

        public List<Map> ParseToMaps(){
            return ParseMapsInPath(_path);
        }

        public List<Session> ParseToSessions(){
            var maps = ParseToMaps();
            var sessions = new List<Session>();

            foreach (Map map in maps){
                sessions.Add(_transformer.TransformTo(map));
            }

            return sessions;
        }

        private static string GetFileContents(FileInfo file){
            string fileContents = "";
            using (StreamReader reader = new StreamReader(file.OpenRead())){
                fileContents = reader.ReadToEnd();
            }

            return fileContents;
        }

        private static void ParseFilePart(FileInfo file, string filePart, Map map){
            if (filePart.StartsWith(Config.KillInfoStart)){
                map.KillInfos = KillParser.Parse(file, filePart);
            } else if (filePart.StartsWith(Config.WeaponInfoStart)){
                map.WeaponInfos = WeaponParser.Parse(file, filePart);
            } else if (filePart.StartsWith(Config.SummaryInfoStart)){
                map.SummaryInfo = SummaryParser.Parse(file, filePart);
            } else if (filePart.StartsWith(Config.SettingsInfoStart)){
                map.SettingInfo = SettingParser.Parse(file, filePart);
            } else{
                throw new Exception($"Part not recognized.");
            }
        }

        private static Map ParseFileToMap(FileInfo file){
            Map map = new Map();
            // Get complete content
            string fileContents = GetFileContents(file);

            // splits where 2 End lines are after each other.
            var fileParts = fileContents.Split(new string[]{Environment.NewLine + Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string filePart in fileParts){
                ParseFilePart(file, filePart, map);
            }

            return map;
        }

        private List<Map> ParseMapsInPath(string path){
            // Get directory info and files
            Console.WriteLine($"Reading all csv files in {path}");
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] csvFiles = directoryInfo.GetFiles("*.csv");
            Console.WriteLine($"Found: {csvFiles.Length} files.");

            // Create maps to save our progress
            List<Map> maps = new List<Map>();

            // Read all files
            foreach (FileInfo file in csvFiles){
                Map map = ParseFileToMap(file);
                map.FinalizeParsing(file.Name);
                maps.Add(map);
            }

            return maps;
        }
    }
}