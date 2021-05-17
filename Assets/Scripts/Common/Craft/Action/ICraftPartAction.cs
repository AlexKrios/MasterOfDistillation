using Assets.Scripts.Objects.Item.Recipe;

namespace Assets.Scripts.Common.Craft.Action
{
    public interface ICraftPartAction
    {
        bool IsEnough(PartObject part);
        void Remove(PartObject part);
    }
}
