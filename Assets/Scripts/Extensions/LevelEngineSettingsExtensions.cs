using System;
using Models;

namespace Extensions
{
    public static class LevelEngineSettingsExtensions
    {
        public static float GetEngineValue(this LevelEngineSettings levelEngineSettings, string levelNumber, string pointNumber,
            string engineNumber)
        {
            try
            {
                return levelEngineSettings.PointSettings[levelNumber].Engine[pointNumber].EnginePower[engineNumber];
            }
            catch (Exception exc)
            {
                throw new Exception("Something wrong with settings dictionary. Exception: " + exc);
            }
        }
    }
}