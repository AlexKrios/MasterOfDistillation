using Assets.Scripts.UI.Craft;
using Assets.Scripts.UI.Level;
using Assets.Scripts.UI.Money;
using Assets.Scripts.UI.Raw;
using Assets.Scripts.UI.Storage;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.DI.Scene.Main
{
    [CreateAssetMenu(menuName = "DI Settings/Main Scene")]
    public class SceneSettingsInstaller : ScriptableObjectInstaller<SceneSettingsInstaller>
    {
        public MoneyUiFactory.Settings MoneyUi;
        public LevelUiFactory.Settings LevelUi;
        public RawUiFactory.Settings RawUi;

        public CraftMenuUiFactory.Settings CraftMenuUi;
        public StorageMenuUiFactory.Settings StorageMenuUi;

        public override void InstallBindings()
        {
            Container.BindInstance(MoneyUi);
            Container.BindInstance(LevelUi);
            Container.BindInstance(RawUi);

            Container.BindInstance(CraftMenuUi);
            Container.BindInstance(StorageMenuUi);
        }
    }
}