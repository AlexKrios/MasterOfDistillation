using Scripts.Objects;
using System.Collections.Generic;

namespace Scripts.Stores.Level
{
    public interface ILevelStore
    {
        List<LevelExperienceObject> LevelsExperience { get; set; }
        int Level { get; set; }
        float CurrentExperience { get; set; }
        float LevelExperience { get; set; }
    }
}
