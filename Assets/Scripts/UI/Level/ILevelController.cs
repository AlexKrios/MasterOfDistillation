using Scripts.Objects;
using System.Collections.Generic;

namespace Scripts.UI.Level
{
    public interface ILevelController
    {
        List<LevelExpObject> LevelsExpirience { get; set; }
        int Level { get; set; }
        float CurExpirience { get; set; }
        float LevelExpirience { get; set; }

        void SetLevelExpirience();
        void SetLevelPercent();
        void SetExpirienceText();
    }
}
