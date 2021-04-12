using Scripts.Objects;
using System.Collections.Generic;

namespace Scripts.Stores.Level
{
    public interface ILevelStore
    {
        LevelObject LevelInfo { get; set; }

        List<LevelExperienceObject> ExperienceMax { get; set; }
        int Level { get; set; }
        float Experience { get; set; }
        float ExperienceCap { get; set; }
    }
}
