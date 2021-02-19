using UnityEngine.Events;

namespace Scripts.UI.Level
{
    public interface ILevelUIController
    {
        UnityEvent OnSetLevelText { get; set; }
        UnityEvent OnSetLevelExperience { get; set; }
        UnityEvent OnSetLevelPercent { get; set; }
    }
}
