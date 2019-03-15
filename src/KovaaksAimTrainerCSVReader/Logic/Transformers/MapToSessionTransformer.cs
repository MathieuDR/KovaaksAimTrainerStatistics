#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - MapToSessionTransformer.cs
// CREATED:       12/03/2019 (23:00)
// MODIFIED:      12/03/2019 (23:14)
// MODIFIED BY:    (Mathieu)

#endregion

using System.Linq;
using KovaaksAimTrainerCSVReader.Models;
using KovaaksAimTrainerCSVReader.Models.Enum;

namespace KovaaksAimTrainerCSVReader.Logic.Transformers{
    public class MapToSessionTransformer{
        public Session TransformTo(Map map){
            Session session = new Session();

            session.Score = map.SummaryInfo.Score;

            int shots = map.WeaponInfos.Select(w => w.Shots).Sum();
            int hits = map.WeaponInfos.Select(w => w.Hits).Sum();
            session.Accuracy = hits / (double) shots;
            session.Duration = map.Duration;
            session.TimeStamp = map.Timestamp;
            session.Name = map.Name;

            // Add other types here in if else (Free Play?)
            if (map.IsChallenge){
                session.sessionType = SessionType.Challenge;
            } else{ 
                session.sessionType = SessionType.Unknown;
            }

            session.ShouldCountStats = !map.KillInfos.Any(k => k.Cheated);


            return session;
        }
    }
}