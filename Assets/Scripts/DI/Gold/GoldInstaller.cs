using Scripts.UI.Gold;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.DI.Gold
{
    public class GoldInstaller : MonoInstaller<GoldInstaller>
    {
        [SerializeField] private Text _goldText;

        public override void InstallBindings()
        {
            Container.Bind<IGoldController>()
            .To<GoldController>()
            .AsSingle()
            .WithArguments(_goldText)
            .NonLazy();
        }
    }
}