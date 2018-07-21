using System;
using System.Collections.Generic;

namespace Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime FirstLogDate { get; set; }
        public DateTime LastLogDate { get; set; }
        public List<Record> RecordsCollection { get; set; }
        public LevelEngineSettings LevelEngineSettings { get; set; }

    }
}