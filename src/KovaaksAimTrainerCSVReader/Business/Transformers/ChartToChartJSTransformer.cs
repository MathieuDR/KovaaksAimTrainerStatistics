#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartToChartJSTransformer.cs
// CREATED:       15/03/2019 (23:24)
// MODIFIED:      16/03/2019 (14:42)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using KovaaksAimTrainerCSVReader.Models.output;
using KovaaksAimTrainerCSVReader.Models.output.Chart_Js;

namespace KovaaksAimTrainerCSVReader.Business.Transformers{
    public static class ChartToChartJsTransformer{
        public static ChartJs TransformToGraphJs(this Chart chart){
            throw new NotImplementedException();
        }

        public static ChartJsData TransformToGraphJs(this ChartCollection chart){
            throw new NotImplementedException();
        }
    }
}