#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - KovaaksJsonGenerator.cs
// CREATED:       // ()
// MODIFIED:      14/03/2019 (22:01)
// MODIFIED BY:    (Mathieu)
#endregion

using System;
using System.IO;
using KovaaksAimTrainerCSVReader.Models.output;
using KovaaksAimTrainerCSVReader.Models.output.Chart_Js;
using Newtonsoft.Json;

namespace KovaaksAimTrainerCSVReader.Logic.Output{
    internal class KovaaksJsonGenerator{
        private readonly string _outputDirectory;
        private readonly string _outputFile;
        private readonly ChartJSData _chartJsData;

        public KovaaksJsonGenerator(string outputDirectory, string outputFile, ChartJSData chartJsData){
            _outputDirectory = outputDirectory;
            _outputFile = outputFile;
            _chartJsData = chartJsData;
        }

        public string Generate(){
            string json = JsonConvert.SerializeObject(_chartJsData);

            var file = $@"var data = {json}";
            var path = Path.Combine(_outputDirectory,_outputFile);

            using (StreamWriter writer = new StreamWriter(path, false)){
                writer.WriteLine(file);
            }

            return path;
        }
    }
}