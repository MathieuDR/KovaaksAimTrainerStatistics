﻿#region HEADER

// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - StatisticGenerator.cs
// CREATED:       15/03/2019 (19:58)
// MODIFIED:      16/03/2019 (14:11)
// MODIFIED BY:    (Mathieu)

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using KovaaksAimTrainerCSVReader.Models;
using KovaaksAimTrainerCSVReader.Models.Enum;
using KovaaksAimTrainerCSVReader.Models.output;
using KovaaksAimTrainerCSVReader.Models.output.Chart_Js;

namespace KovaaksAimTrainerCSVReader.Business.Statistics{
    public class StatisticGenerator{
        private readonly ChartCollection _output;

        private readonly Dictionary<DateTime, List<Session>> _sessionPerDates;
        private readonly List<Session> _sessions;

        private List<DateTime> _allDates;

        private List<string> _allDatesLabels;

        private List<string> _mapsList;

        public StatisticGenerator(List<Session> sessions, bool allowCheated){
            Console.WriteLine($"Making statistics.");
            _sessionPerDates = new Dictionary<DateTime, List<Session>>();

            // Use all if we allow cheated.
            _sessions = allowCheated ? sessions : sessions.Where(s => s.ShouldCountStats).ToList();
            _output = new ChartCollection(_sessions);
        }

        public List<string> AllDatesLabels{
            get{
                return _allDatesLabels ?? (_allDatesLabels = AllDates.Select(date => date.ToString("dd/MM")).ToList());
            }
        }

        public List<string> MapList{
            get{
                return _mapsList ?? (_mapsList = _sessions.Select(s => s.Name).Distinct().OrderBy(name => name).ToList());
            }
        }

        public List<DateTime> AllDates{
            get{
                return _allDates ?? (_allDates = _sessions.Select(s => s.TimeStamp.Date).Distinct().OrderBy(date => date).ToList());
            }
        }

        public void CreateAccuracyChart(){ }

        public void CreateImprovementChart(){ }

        public void CreateMapPlayRateChart(){ }

        public void CreateScoreChart(){
            Console.WriteLine($"Creating score chart");
            Chart chart = new Chart(ChartType.StandardLine, "Average Scores");

            foreach (string map in MapList){
                var data = new List<double?>();
                foreach (DateTime date in AllDates){
                    var sessionOnDate = GetSessionPerDate(date);

                    var mapSessions = sessionOnDate.Where(s => s.Name == map).ToList();

                    if (!mapSessions.Any()){
                        Console.WriteLine($"Didn't play map {map} on {date:dd/MM}");
                        data.Add(null);
                        continue;
                    }

                    var average = mapSessions.Select(s => s.Score).Average();
                    data.Add(average);
                }

                chart.AddChartSerie(map, data);
            }


            _output.AddChart(chart);
        }

        public void CreateSessionsPerDayChart(){ }

        public ChartCollection GetOutput(){
            return _output;
        }

        private List<Session> GetSessionPerDate(DateTime date){
            if (!_sessionPerDates.TryGetValue(date.Date, out List<Session> result)){
                result = _sessions.Where(s => s.TimeStamp.Date == date).ToList();
                _sessionPerDates.Add(date.Date, result);
            }

            return result;
        }
    }
}