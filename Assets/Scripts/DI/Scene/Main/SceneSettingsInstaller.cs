using Scripts.UI.Level;
using Scripts.UI.Money;
using Scripts.UI.Product;
using Scripts.UI.Raw;
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
        public ComponentUIFactory.Settings ComponentUI;
        public ProductUIFactory.Settings ProductUI;

        public override void InstallBindings()
        {
            Container.BindInstance(MoneyUI);
            Container.BindInstance(LevelUI);
            Container.BindInstance(RawUI);
            Container.BindInstance(ComponentUI);
            Container.BindInstance(ProductUI);
        }
    }
}