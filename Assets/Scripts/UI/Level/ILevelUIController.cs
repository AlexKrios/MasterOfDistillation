using UnityEngine.Events;

namespace Assets.Scripts.UI.Level
{
    public interface ILevelUiController
    {
        UnityEvent OnSetLevelText { get; set; }
        UnityEvent OnSetLevelExperience { get; set; }
        UnityEvent OnSetLevelPercent { get; set; }
    }
}
