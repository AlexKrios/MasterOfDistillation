using Assets.Scripts.Ui.Craft.Item;
using Assets.Scripts.Ui.Craft.Tab;
using Assets.Scripts.Ui.Craft.Title;
using Assets.Scripts.UI.Craft.Part;
using Assets.Scripts.UI.Craft.Product;
using Assets.Scripts.UI.Craft.Quality;

namespace Assets.Scripts.Ui.Craft
{
    public interface ICraftMenu
    {
        ITitleSection Title { get; }
        ITabsGroup Tabs { get; }
        IItemsGroup Items { get; }
        ProductCell Product { get; }
        PartGroup PartGroup { get; }
        QualityButton QualityBtn { get; }
    }
}
