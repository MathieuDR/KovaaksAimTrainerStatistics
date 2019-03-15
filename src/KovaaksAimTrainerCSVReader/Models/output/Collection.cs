#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - Collection.cs
// CREATED:       15/03/2019 (23:38)
// MODIFIED:      15/03/2019 (23:38)
// MODIFIED BY:    (Mathieu)
#endregion

using System.Collections.Generic;

namespace KovaaksAimTrainerCSVReader.Models.output{
    public class Collection{
        public List<Chart> Charts{ get; set; }
        public List<Session> Sessions{ get; set; }
    }
}