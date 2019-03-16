#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartToHighChartTransformer.cs
// CREATED:       15/03/2019 (23:24)
// MODIFIED:      16/03/2019 (14:11)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using KovaaksAimTrainerCSVReader.Models.output;
using KovaaksAimTrainerCSVReader.Models.output.HighChart;

namespace KovaaksAimTrainerCSVReader.Business.Transformers{
    public class ChartToHighChartTransformer{
        public HighChart<T> TransformTo<T>(Chart chart) where T : struct{
            throw new NotImplementedException();
        }
    }
}