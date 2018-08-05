using System.Collections.Generic;

namespace Models
{
    public class LevelEngineSettings
    {
     //   public LevelType LevelType { get; set; }
        public Dictionary<string, PointSettings> PointSettings { get; set; } = new Dictionary<string, PointSettings>();
    }

    public class PointSettings
    {
        public Dictionary<string,Engine> Engine { get; set; } = new Dictionary<string, Engine>();
    }

    public class Engine
    {
        public Dictionary<string, EngineValues> EnginePower { get; set; } = new Dictionary<string, EngineValues>();
        //TODO: tutaj mozna rozszerzyc to co uzytkownik zmienia

    }

    public class EngineValues
    {
        public float Power { get; set; }
        public float Delay { get; set; }
        public bool StepPower { get; set; }
    }
}