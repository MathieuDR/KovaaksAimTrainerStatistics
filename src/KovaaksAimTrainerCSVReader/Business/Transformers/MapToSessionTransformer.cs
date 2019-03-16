#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - MapToSessionTransformer.cs
// CREATED:       15/03/2019 (19:58)
// MODIFIED:      16/03/2019 (14:10)
// MODIFIED BY:    (Mathieu)

#endregion

using System.Linq;
using KovaaksAimTrainerCSVReader.Models;
using KovaaksAimTrainerCSVReader.Models.Enum;
using KovaaksAimTrainerCSVReader.Models.Parsing;

namespace KovaaksAimTrainerCSVReader.Business.Transformers{
    public static class MapToSessionTransformer{
        public static Session TransformToSession(this Map map){
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