using Scripts.Objects.Part;

namespace Scripts.Common.Craft.Action
{
    public interface ICraftPartAction
    {
        bool IsEnough(PartObject part);
        void Remove(PartObject part);
    }
}
