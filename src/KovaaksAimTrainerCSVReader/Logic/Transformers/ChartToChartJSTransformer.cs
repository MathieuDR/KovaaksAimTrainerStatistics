#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartToChartJSTransformer.cs
// CREATED:       15/03/2019 (23:24)
// MODIFIED:      15/03/2019 (23:24)
// MODIFIED BY:    (Mathieu)
#endregion

using System;
using KovaaksAimTrainerCSVReader.Models.output;
using KovaaksAimTrainerCSVReader.Models.output.Chart_Js;

namespace KovaaksAimTrainerCSVReader.Logic.Transformers{
    public class ChartToChartJSTransformer{
        public ChartJS<T> TransformTo<T>(Chart<T> chart) where T: struct {
            throw new NotImplementedException();
            ChartJS<T> result = new ChartJS<T>(null,null);
            return result;
        }
    }
}