#region HEADER
// FILE:          KovaaksAimTrainerCSVReader - KovaaksAimTrainerCSVReader - Config.cs
// CREATED:       11/03/2019 (20:14)
// MODIFIED:      11/03/2019 (20:14)
// MODIFIED BY:    (Mathieu)
#endregion

namespace KovaaksAimTrainerCSVReader.Settings{
    public static class Config{
        public static string InputPath{ get;  } = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\FPSAimTrainer\\FPSAimTrainer\\stats";
        public static string BeforeTimeStamp { get; } = " - ";
        public static string AfterTimeStamp { get; } = " ";
        public static string KillInfoStart{ get; } = "Kill #,";
        public static string WeaponInfoStart{ get; } = "Weapon,";
        public static string SummaryInfoStart { get; } = "Kills:,";
        public static string SettingsInfoStart { get; } = "Input Lag:,";
        public static string FileDateTimeFormat { get; } = "yyyy.MM.dd-HH.mm.ss";
        public static string KillTimeStampFormat { get; } = "HH:mm:ss:fff";

        // TODO WHAT HAPPENS ON MINUTES? NOT ENOUGH DATA!
        public static string KillTimeToKillFormat { get; } = "s's'";

        public static string ChallengeFileName { get; } = "- Challenge -";
        public static string OutputFileName { get; } = @"js\data.js";
        public static string IndexPage { get; } = @"Prototype.html";

        public static string OutputDirectory(){
            var codebase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            var dir = System.IO.Path.GetDirectoryName(codebase);
            var dirWithoutFile = dir.Replace(@"file:\", "");

            return $@"{dirWithoutFile}\Html";
        }
    }
}