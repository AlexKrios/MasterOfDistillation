using Assets.Scripts.Stores.Product.Recipe;

namespace Assets.Scripts.Controllers.Craft.Action
{
    public interface ICraftPartAction
    {
        bool IsEnough(PartObject part);
        void Remove(PartObject part);
    }
}
