using Scripts.UI.Level;
using Scripts.UI.Money;
using UnityEngine;
using Zenject;

namespace Scripts.DI.Scene.Main
{
    [CreateAssetMenu(menuName = "DI Settings/Main Scene")]
    public class SceneSettingsInstaller : ScriptableObjectInstaller<SceneSettingsInstaller>
    {
        public MoneyUIFactory.Settings MoneyUI;
        public LevelUIFactory.Settings LevelUI;

        public override void InstallBindings()
        {
            Container.BindInstance(MoneyUI);
            Container.BindInstance(LevelUI);
        }
    }
}