#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - ChartCollection.cs
// CREATED:       15/03/2019 (23:38)
// MODIFIED:      16/03/2019 (14:11)
// MODIFIED BY:    (Mathieu)

#endregion

using System.Collections.Generic;

namespace KovaaksAimTrainerCSVReader.Models.output{
    public class ChartCollection{
        private readonly List<Chart> _charts;

        public ChartCollection(List<Session> sessions){
            Sessions = sessions;
            _charts = new List<Chart>();
        }

        public List<Session> Sessions{ get; }

        public IReadOnlyList<Chart> Charts{
            get{
                return _charts.AsReadOnly();
            }
        }

        public void AddChart(Chart chart){
            _charts.Add(chart);
        }
    }
}