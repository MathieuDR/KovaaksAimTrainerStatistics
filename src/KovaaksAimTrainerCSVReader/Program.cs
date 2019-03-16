#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - Program.cs
// CREATED:       15/03/2019 (19:58)
// MODIFIED:      16/03/2019 (14:10)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using KovaaksAimTrainerCSVReader.Business.Output;
using KovaaksAimTrainerCSVReader.Business.Parsing;
using KovaaksAimTrainerCSVReader.Business.Statistics;
using KovaaksAimTrainerCSVReader.Models;
using KovaaksAimTrainerCSVReader.Models.output.Chart_Js;
using KovaaksAimTrainerCSVReader.Settings;

namespace KovaaksAimTrainerCSVReader{
    class Program{
        public static void Main(string[] args){
            try{
                // parse
                KovaaksCSVParser parser = new KovaaksCSVParser(Config.InputPath);
                List<Session> sessions = parser.ParseToSessions();

                // generate stats
                var generator = new StatisticGenerator(sessions, false);
                generator.CreateScoreChart();

                // Parse to file
                var output = generator.GetOutput();
                ChartJsJsonGenerator jsonGenerator = new ChartJsJsonGenerator(Config.OutputDirectory(), Config.OutputFileName, output.TransformToGraphJs());
                jsonGenerator.Generate();

                // Start page
                var filePath = $@"{Path.Combine(Config.OutputDirectory(), Config.IndexPage)}";
                using (var proc = Process.Start(@"cmd.exe ", $@"/c {filePath}")){ }
            } catch (Exception e){
                Console.WriteLine($"{e.Message}");
                Console.WriteLine($"{e.StackTrace}");
                Console.WriteLine($"Terminating");
            } finally{
                Console.WriteLine("Press enter to close...");
                Console.ReadLine();
            }
        }
    }
}