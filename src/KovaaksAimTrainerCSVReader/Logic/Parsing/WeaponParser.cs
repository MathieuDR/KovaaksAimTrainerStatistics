#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - WeaponParser.cs
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
    public class WeaponParser{
        public static List<WeaponInfo> Parse(FileInfo file, string rawInfo){
            // TODO CAN MAKE THIS GENERIC
            Console.WriteLine($"Reading Weapons Info of {file.Name}");
            List<WeaponInfo> result;

            using (var csv = new CsvReader(new StringReader(rawInfo))){
                csv.Configuration.CultureInfo = CultureInfo.InvariantCulture;
                csv.Configuration.MissingFieldFound = null;
                result = csv.GetRecords<WeaponInfo>().ToList();
            }

            return result;
        }
    }
}