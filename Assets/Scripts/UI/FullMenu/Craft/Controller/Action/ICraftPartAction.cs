using Assets.Scripts.Objects.Item.Recipe;

namespace Assets.Scripts.Ui.FullMenu.Craft.Controller.Action
{
    public interface ICraftPartAction
    {
        bool IsEnough(PartObject part);
        void Remove(PartObject part);
    }
}
