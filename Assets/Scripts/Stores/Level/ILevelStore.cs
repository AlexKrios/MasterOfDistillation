using Scripts.Objects;
using System.Collections.Generic;

namespace Scripts.Stores.Level
{
    public interface ILevelStore
    {
        List<LevelExpObject> LevelsExpirience { get; set; }
        int Level { get; set; }
        float CurrentExpirience { get; set; }
        float LevelExpirience { get; set; }
    }
}
