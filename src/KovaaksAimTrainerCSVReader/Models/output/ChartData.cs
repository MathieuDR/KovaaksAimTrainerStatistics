#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - Data.cs
// CREATED:       15/03/2019 (23:30)
// MODIFIED:      16/03/2019 (01:14)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KovaaksAimTrainerCSVReader.Models.output{
    public abstract class ChartData{ }

    [JsonConverter(typeof(MetaDataConverter))]
    public class ChartData<T> : ChartData where T : struct{
        public ChartData(T? value){
            Value = value;
        }

        public T? Value{ get; set; }
    }

    [JsonConverter(typeof(MetaDataConverter))]
    public class StringData : ChartData{
        public StringData(string value){
            Value = value;
        }

        public string Value{ get; set; }
    }

    public static class MetaDataHelper{
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

    public class MetaDataConverter : JsonConverter{
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