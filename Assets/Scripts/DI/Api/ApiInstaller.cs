using Scripts.Api;
using Zenject;

namespace Scripts.DI.Api
{
    public class ApiInstaller : MonoInstaller<ApiInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IApiManager>()
            .To<ApiManager>()
            .AsSingle()
            .NonLazy();
        }
    }
}