using Scripts.UI.Level;
using Scripts.UI.Money;
using Scripts.UI.Raw;
using Scripts.UI.Workshop.Craft;
using Scripts.UI.Workshop.Storage;
using UnityEngine;
using Zenject;

namespace Scripts.DI.Scene.Main
{
    [CreateAssetMenu(menuName = "DI Settings/Main Scene")]
    public class SceneSettingsInstaller : ScriptableObjectInstaller<SceneSettingsInstaller>
    {
        public MoneyUIFactory.Settings MoneyUI;
        public LevelUIFactory.Settings LevelUI;
        public RawUIFactory.Settings RawUI;

        public CraftMenuUIFactory.Settings CraftMenuUI;
        public StorageMenuUIFactory.Settings StorageMenuUI;

        public override void InstallBindings()
        {
            Container.BindInstance(MoneyUI);
            Container.BindInstance(LevelUI);
            Container.BindInstance(RawUI);

            Container.BindInstance(CraftMenuUI);
            Container.BindInstance(StorageMenuUI);
        }
    }
}