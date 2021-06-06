using Assets.Scripts.Ui.Level;
using Assets.Scripts.Ui.Money;
using Assets.Scripts.Ui.Order;
using Assets.Scripts.Ui.Order.Result;
using Assets.Scripts.Ui.Raw;
using UnityEngine;
using Zenject;
// ReSharper disable UnassignedField.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Assets.Scripts.Di.Scene.Main
{
    [CreateAssetMenu(menuName = "DI Settings/Main Scene")]
    public class SceneSettingsInstaller : ScriptableObjectInstaller<SceneSettingsInstaller>
    {
        public MoneyUiFactory.Settings MoneyUi;
        public LevelUiFactory.Settings LevelUi;
        public RawUiFactory.Settings RawUi;

        public CraftGroupFactory.Settings CraftGroup;
        public ResultCanvasFactory.Settings ResultCanvas;

        public override void InstallBindings()
        {
            Container.BindInstance(MoneyUi);
            Container.BindInstance(LevelUi);
            Container.BindInstance(RawUi);

            Container.BindInstance(CraftGroup);
            Container.BindInstance(ResultCanvas);
        }
    }
}