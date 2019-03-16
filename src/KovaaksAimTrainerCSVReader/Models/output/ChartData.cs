#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartData.cs
// CREATED:       15/03/2019 (23:30)
// MODIFIED:      16/03/2019 (14:11)
// MODIFIED BY:    (Mathieu)

#endregion

using KovaaksAimTrainerCSVReader.Business.JsonConvertors;
using Newtonsoft.Json;

namespace KovaaksAimTrainerCSVReader.Models.output{
    public abstract class ChartData{ }

    [JsonConverter(typeof(ChartDataConverter))]
    public class ChartData<T> : ChartData where T : struct{
        public ChartData(T? value){
            Value = value;
        }

        public T? Value{ get; set; }
    }

    [JsonConverter(typeof(ChartDataConverter))]
    public class StringData : ChartData{
        public StringData(string value){
            Value = value;
        }

        public string Value{ get; set; }
    }
}