#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartToHighChartTransformer.cs
// CREATED:       15/03/2019 (23:24)
// MODIFIED:      16/03/2019 (14:41)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using KovaaksAimTrainerCSVReader.Models.output;
using KovaaksAimTrainerCSVReader.Models.output.HighChart;

namespace KovaaksAimTrainerCSVReader.Business.Transformers{
    public static class ChartToHighChartTransformer{
        public static HighChartData TransformToHighChart(this Chart chart){ // Fix to correct return model
            throw new NotImplementedException();
        }

        public static HighChartData TransformToHighChart(this ChartCollection chart){
            throw new NotImplementedException();
        }
    }
}