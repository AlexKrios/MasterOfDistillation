using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Ui.Level
{
    [UsedImplicitly]
    public class LevelUi : MonoBehaviour
    {
        public Image LevelIcon;
        public Text LevelText;
        public Text LevelPercentText;

        public class Factory : PlaceholderFactory<LevelUi> { }
    }
}
