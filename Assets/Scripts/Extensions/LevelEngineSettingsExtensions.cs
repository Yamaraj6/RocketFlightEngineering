using System;
using System.Diagnostics;
using Models;
using Debug = UnityEngine.Debug;

namespace Extensions
{
    public static class LevelEngineSettingsExtensions
    {
        public static EngineValues GetEngineValue(this LevelEngineSettings levelEngineSettings, string levelNumber, string pointNumber,
            string engineNumber)
        {
            try
            {
                return levelEngineSettings.PointSettings[levelNumber].Engine[pointNumber].EnginePower[engineNumber];
            }
            catch (Exception exc)
            {
                Debug.LogWarning("Could not provide engineValue, returning 0");
                return new EngineValues()
                {
                    Power = 0,
                    Delay = 0,
                    StepPower = false
                };
            }
        }
    }
}