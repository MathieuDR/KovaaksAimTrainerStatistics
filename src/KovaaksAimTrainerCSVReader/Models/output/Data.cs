#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - Data.cs
// CREATED:       15/03/2019 (23:30)
// MODIFIED:      16/03/2019 (00:40)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KovaaksAimTrainerCSVReader.Models.output{
    public abstract class Metadata{ }

    // extend abstract Metadata class
    [JsonConverter(typeof(MetaDataConverter))]
    public class Metadata<T> : Metadata where T : struct{
        public Metadata(T? value){
            MetaDataType = value;
        }

        public Nullable<T> MetaDataType{ get; set; }
    }

    public static class MetaDataHelper{
        public static List<Metadata<T>> ToMetaDataList<T>(this List<T?> data) where T : struct{
            List<Metadata<T>> result = new List<Metadata<T>>();

            foreach (T? value in data){
                result.Add(new Metadata<T>(value));
            }

            return result;
        }
    }

    public class MetaDataConverter : JsonConverter{
        public override bool CanConvert(Type objectType){
            return (objectType == typeof(Metadata));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer){
            string value = JToken.Load(reader).ToString();

            if (double.TryParse(value, out double doubleResult)){
                return new Metadata<double>(doubleResult);
            } else if (int.TryParse(value, out int intResult)){
                return new Metadata<int>(intResult);
            }

            throw new Exception($"Value not supported: {value}");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer){
            bool writen = false;
            if (value is Metadata<int> intData){
                if (intData.MetaDataType.HasValue){
                    JToken.FromObject(intData.MetaDataType).WriteTo(writer);
                } else{
                    writer.WriteNull();
                }

                writen = true;
            } else if (value is Metadata<double> doubleData){
                if (doubleData.MetaDataType.HasValue){
                    JToken.FromObject(doubleData.MetaDataType).WriteTo(writer);
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