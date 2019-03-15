#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - KillParser.cs
// CREATED:       12/03/2019 (23:28)
// MODIFIED:      12/03/2019 (23:34)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using KovaaksAimTrainerCSVReader.Models;

namespace KovaaksAimTrainerCSVReader.Logic{
    public class KillParser{
        public static List<KillInfo> Parse(FileInfo file, string rawInfo){
            // TODO CAN MAKE THIS GENERIC
            Console.WriteLine($"Reading Kill Info of {file.Name}");
            List<KillInfo> result;

            using (var csv = new CsvReader(new StringReader(rawInfo))){
                csv.Configuration.CultureInfo = CultureInfo.InvariantCulture;
                result = csv.GetRecords<KillInfo>().ToList();
            }

            return result;
        }
    }
}