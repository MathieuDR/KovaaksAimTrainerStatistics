#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - KovaaksJsonGenerator.cs
// CREATED:       15/03/2019 (19:58)
// MODIFIED:      16/03/2019 (14:11)
// MODIFIED BY:    (Mathieu)

#endregion

using System.IO;
using KovaaksAimTrainerCSVReader.Models.output.Chart_Js;
using Newtonsoft.Json;

namespace KovaaksAimTrainerCSVReader.Business.Output{
    internal class KovaaksJsonGenerator{
        private readonly ChartJsData _chartJsData;
        private readonly string _outputDirectory;
        private readonly string _outputFile;

        public KovaaksJsonGenerator(string outputDirectory, string outputFile, ChartJsData chartJsData){
            _outputDirectory = outputDirectory;
            _outputFile = outputFile;
            _chartJsData = chartJsData;
        }

        public string Generate(){
            string json = JsonConvert.SerializeObject(_chartJsData);

            var file = $@"var data = {json}";
            var path = Path.Combine(_outputDirectory, _outputFile);

            using (StreamWriter writer = new StreamWriter(path, false)){
                writer.WriteLine(file);
            }

            return path;
        }
    }
}