using Assets.Scripts.Ui.Craft;
using Assets.Scripts.Ui.Craft.Item;
using Assets.Scripts.Ui.Craft.Tab;
using Assets.Scripts.Ui.Craft.Title;
using Assets.Scripts.UI.Craft.Create;
using Assets.Scripts.UI.Craft.Item;
using Assets.Scripts.UI.Craft.Part;
using Assets.Scripts.UI.Craft.Product;
using Assets.Scripts.UI.Craft.Quality;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;
#pragma warning disable 649

namespace Assets.Scripts.UI.Craft
{
    [UsedImplicitly]
    public class CraftMenu : MonoBehaviour, ICraftMenu
    {
        [Inject] private readonly TitleSection.Factory _titleSectionFactory;
        [Inject] private readonly TabsGroup.Factory _typeTabsFactory;
        [Inject] private readonly ItemsGroup.Factory _itemGroupFactory;

        public ITitleSection Title { get; private set; }
        public ITabsGroup Tabs { get; private set; }
        public IItemsGroup Items { get; private set; }

        [SerializeField] private ProductCell _product;
        public ProductCell Product => _product;

        [SerializeField] private PartGroup _partGroup;
        public PartGroup PartGroup => _partGroup;

        [SerializeField] private CreateButton _createBtn;
        public CreateButton CreateBtn => _createBtn;

        [SerializeField] private QualityButton _qualityBtn;
        public QualityButton QualityBtn => _qualityBtn;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            Title = _titleSectionFactory.Create();
            Tabs = _typeTabsFactory.Create();
            Items = _itemGroupFactory.Create();
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<CraftMenu> { }
    }
}
