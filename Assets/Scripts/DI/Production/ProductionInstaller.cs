using Scripts.Scenes.Village.Buildings.Production;
using Zenject;

namespace Scripts.DI.Gold
{
    public class ProductionInstaller : MonoInstaller<ProductionInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IProductionController>()
            .To<ProductionController>()
            .AsSingle()
            .NonLazy();
        }
    }
}