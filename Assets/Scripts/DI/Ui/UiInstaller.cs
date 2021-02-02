using Scripts.Scenes.Village.UI.Building;
using Scripts.UI;
using UnityEngine;
using Zenject;

namespace Scripts.DI.Ui
{
    public class UiInstaller : MonoInstaller<UiInstaller>
    {
        [SerializeField] private GameObject _mainCanvas;

        public override void InstallBindings()
        {
            Container.Bind<IUiController>()
            .To<UiController>()
            .AsSingle()
            .WithArguments(_mainCanvas)
            .NonLazy();

            Container.BindFactory<string, BuildingMenu, BuildingMenu.Factory>().FromFactory<BuildingMenuFactory>();
        }
    }
}