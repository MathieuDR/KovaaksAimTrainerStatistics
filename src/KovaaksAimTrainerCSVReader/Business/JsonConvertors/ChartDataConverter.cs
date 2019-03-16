#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartDataConverter.cs
// CREATED:       16/03/2019 (14:08)
// MODIFIED:      16/03/2019 (14:11)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using KovaaksAimTrainerCSVReader.Models.output;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KovaaksAimTrainerCSVReader.Business.JsonConvertors{
    public class ChartDataConverter : JsonConverter{
        public override bool CanConvert(Type objectType){
            return (objectType == typeof(ChartData));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer){
            string value = JToken.Load(reader).ToString();

            if (double.TryParse(value, out double doubleResult)){
                return new ChartData<double>(doubleResult);
            }

            if (int.TryParse(value, out int intResult)){
                return new ChartData<int>(intResult);
            }

            return new StringData(value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer){
            bool writen = false;
            if (value is ChartData<int> intData){
                if (intData.Value.HasValue){
                    JToken.FromObject(intData.Value).WriteTo(writer);
                } else{
                    writer.WriteNull();
                }

                writen = true;
            } else if (value is ChartData<double> doubleData){
                if (doubleData.Value.HasValue){
                    JToken.FromObject(Math.Round(doubleData.Value.Value, 2)).WriteTo(writer);
                } else{
                    writer.WriteNull();
                }

                writen = true;
            } else if (value is StringData stringData){
                if (stringData.Value != null){
                    JToken.FromObject(stringData.Value).WriteTo(writer);
                } else{
                    writer.WriteNull();
                }

                writen = true;
            }

            if (!writen){
                throw new ArgumentException($"Type: {value.GetType()} not yet supported");
            }
        }
    }
}