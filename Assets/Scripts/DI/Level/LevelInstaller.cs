using Scripts.UI.Level;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.DI.Level
{
    public class LevelInstaller : MonoInstaller<LevelInstaller>
    {
        [SerializeField] private Text _levelText;
        [SerializeField] private Text _levelPercentText;

        public override void InstallBindings()
        {
            Container.Bind<ILevelController>()
            .To<LevelController>()
            .AsSingle()
            .WithArguments(_levelText, _levelPercentText)
            .NonLazy();
        }
    }
}