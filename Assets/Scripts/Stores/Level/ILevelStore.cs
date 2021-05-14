using Scripts.Objects.Level;
using System.Collections.Generic;

namespace Scripts.Stores.Level
{
    public interface ILevelStore
    {
        LevelObject LevelInfo { get; set; }

        List<int> LevelCaps { get; set; }
        int Level { get; set; }
        float Experience { get; set; }
        float LevelCap { get; set; }
    }
}
