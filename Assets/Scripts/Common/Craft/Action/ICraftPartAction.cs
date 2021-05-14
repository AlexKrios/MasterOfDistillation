using Assets.Scripts.Objects.Product.Part;

namespace Assets.Scripts.Common.Craft.Action
{
    public interface ICraftPartAction
    {
        bool IsEnough(PartObject part);
        void Remove(PartObject part);
    }
}
