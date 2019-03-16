#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - KillParser.cs
// CREATED:       15/03/2019 (19:58)
// MODIFIED:      16/03/2019 (14:11)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using KovaaksAimTrainerCSVReader.Models.Parsing;

namespace KovaaksAimTrainerCSVReader.Business.Parsing{
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