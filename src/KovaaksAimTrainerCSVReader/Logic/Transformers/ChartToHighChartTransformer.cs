#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartToHighChartTransformer.cs
// CREATED:       15/03/2019 (23:24)
// MODIFIED:      15/03/2019 (23:27)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using KovaaksAimTrainerCSVReader.Models.output;
using KovaaksAimTrainerCSVReader.Models.output.HighChart;

namespace KovaaksAimTrainerCSVReader.Logic.Transformers{
    public class ChartToHighChartTransformer{
        public HighChart<T> TransformTo<T>(Chart<T> chart) where T:struct{
            throw new NotImplementedException();
        }
    }
}