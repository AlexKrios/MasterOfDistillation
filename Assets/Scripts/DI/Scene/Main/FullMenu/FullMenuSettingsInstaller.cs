using Assets.Scripts.Ui.FullMenu.Common.Model;
using Assets.Scripts.Ui.FullMenu.Common.Part;
using Assets.Scripts.Ui.FullMenu.Common.Product;
using Assets.Scripts.Ui.FullMenu.Common.Quality;
using Assets.Scripts.Ui.FullMenu.Common.Tab;
using Assets.Scripts.Ui.FullMenu.Craft;
using Assets.Scripts.Ui.FullMenu.Storage;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Assets.Scripts.DI.Scene.Main.FullMenu
{
    [CreateAssetMenu(menuName = "DI Settings/Full Menu")]
    public class FullMenuSettingsInstaller : ScriptableObjectInstaller<FullMenuSettingsInstaller>
    {
        public TabsGroupFactory.Settings TabsGroup;
        public ProductCellFactory.Settings ProductCellSettings;
        public PartGroupFactory.Settings PartsGroupSettings;
        public PartCellFactory.Settings PartCellSettings;
        public QualityButtonFactory.Settings QualityButtonSettings;
        public ModelGroupFactory.Settings ModelGroupSettings;

        public CraftMenuFactory.Settings CraftMenu;
        public StorageMenuFactory.Settings StorageMenu;

        public override void InstallBindings()
        {
            Container.BindInstance(TabsGroup);
            Container.BindInstance(ProductCellSettings);
            Container.BindInstance(PartsGroupSettings);
            Container.BindInstance(PartCellSettings);
            Container.BindInstance(QualityButtonSettings);
            Container.BindInstance(ModelGroupSettings);

            Container.BindInstance(CraftMenu);
            Container.BindInstance(StorageMenu);
        }
    }
}