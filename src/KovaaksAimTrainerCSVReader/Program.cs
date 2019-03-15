#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - Program.cs
// CREATED:       11/03/2019 (20:11)
// MODIFIED:      12/03/2019 (23:41)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using KovaaksAimTrainerCSVReader.Logic;
using KovaaksAimTrainerCSVReader.Logic.Output;
using KovaaksAimTrainerCSVReader.Logic.Statistics;
using KovaaksAimTrainerCSVReader.Models;
using KovaaksAimTrainerCSVReader.Models.output;
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
                Data output = generator.GetOutput();
                KovaaksJsonGenerator jsonGenerator = new KovaaksJsonGenerator(Config.OutputDirectory(), Config.OutputFileName, output);
                jsonGenerator.Generate();

                // Start page
                var filePath = $@"{Path.Combine(Config.OutputDirectory(), Config.IndexPage)}";
                using(var proc = Process.Start(@"cmd.exe ", $@"/c {filePath}")) { }
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