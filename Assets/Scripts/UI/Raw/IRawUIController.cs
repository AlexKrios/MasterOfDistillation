using UnityEngine.Events;

namespace Scripts.UI.Raw
{
    public interface IRawUIController
    {
        UnityEvent OnSetIronText { get; set; }
    }
}
