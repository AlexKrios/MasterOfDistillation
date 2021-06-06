using Assets.Scripts.MainCamera.Disable;
using Assets.Scripts.MainCamera.Target;
using Assets.Scripts.Objects.Item.Craft;
using Assets.Scripts.Ui.FullMenu.Craft;
using Assets.Scripts.Ui.Level;
using Assets.Scripts.Ui.Money;
using Assets.Scripts.Ui.Order;
using Assets.Scripts.Ui.Order.Result;
using Assets.Scripts.Ui.Order.State;
using Assets.Scripts.Ui.Raw;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Di.Scene.Main
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallCameraComponents();
            InstallUiFactory();
        }

        private void InstallCameraComponents()
        {
            Container.Bind<IDisable>().To<Disable>().AsSingle().NonLazy();
            Container.Bind<ITarget>().To<Target>().AsSingle().NonLazy();
        }

        private void InstallUiFactory()
        {
            Container.BindFactory<MoneyUi, MoneyUi.Factory>().FromFactory<MoneyUiFactory>();
            Container.BindFactory<LevelUi, LevelUi.Factory>().FromFactory<LevelUiFactory>();
            Container.BindFactory<RawUi, RawUi.Factory>().FromFactory<RawUiFactory>();

            Container.BindFactory<CraftMenu, CraftMenu.Factory>().FromFactory<CraftMenuFactory>();
            Container.BindFactory<CraftCell, CraftCellEmpty, CraftCellEmpty.Factory>();
            Container.BindFactory<CraftCell, CraftCellBusy, CraftCellBusy.Factory>();
            Container.BindFactory<CraftCell, CraftCellFinish, CraftCellFinish.Factory>();

            Container.BindFactory<CraftObject, ResultCanvas, ResultCanvas.Factory>().FromFactory<ResultCanvasFactory>();
            Container.BindFactory<GameObject, ResultModel, ResultModel.Factory>().FromFactory<ResultModelFactory>();

            Container.BindFactory<CraftGroup, CraftGroup.Factory>().FromFactory<CraftGroupFactory>();
            Container.BindFactory<CraftCell, CraftCell.Factory>().FromFactory<CraftCellFactory>();
            Container.BindFactory<CraftPlusCell, CraftPlusCell.Factory>().FromFactory<CraftPlusCellFactory>();
        }
    }
}