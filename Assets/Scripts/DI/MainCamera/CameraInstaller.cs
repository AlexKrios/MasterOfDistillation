using Scripts.Scenes.Village.Buildings.MainCamera;
using Scripts.Scenes.Village.MainCamera;
using UnityEngine;
using Zenject;

namespace Scripts.DI.MainCamera
{
    public class CameraInstaller : MonoInstaller<CameraInstaller>
    {
        [SerializeField] private Camera _mainCamera;

        public override void InstallBindings()
        {
            Container.Bind<ICameraController>()
                .To<CameraController>()
                .AsSingle()
                .WithArguments(_mainCamera)
                .NonLazy();

            Container.Bind<IDisable>()
                .To<Disable>()
                .AsSingle()
                .NonLazy();

            Container.Bind<ITarget>()
                .To<Target>()
                .AsSingle()
                .NonLazy();
        }
    }
}