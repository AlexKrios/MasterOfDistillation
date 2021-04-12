using UnityEngine.Events;

namespace Scripts.UI.Workshop.Craft
{
    public interface ICraftMenuUIController
    {
        UnityEvent OnSetQualityIcon { get; set; }
    }
}
