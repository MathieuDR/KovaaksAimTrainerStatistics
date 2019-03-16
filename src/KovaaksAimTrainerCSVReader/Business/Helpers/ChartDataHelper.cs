#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartDataHelper.cs
// CREATED:       16/03/2019 (14:07)
// MODIFIED:      16/03/2019 (14:11)
// MODIFIED BY:    (Mathieu)

#endregion

using System.Collections.Generic;
using KovaaksAimTrainerCSVReader.Models.output;

namespace KovaaksAimTrainerCSVReader.Business.Helpers{
    public static class ChartDataHelper{
        public static List<ChartData<T>> ToMetaDataList<T>(this List<T?> data) where T : struct{
            List<ChartData<T>> result = new List<ChartData<T>>();

            foreach (T? value in data){
                result.Add(new ChartData<T>(value));
            }

            return result;
        }

        public static List<StringData> ToMetaDataList(this List<string> data){
            List<StringData> result = new List<StringData>();

            foreach (string value in data){
                result.Add(new StringData(value));
            }

            return result;
        }
    }
}