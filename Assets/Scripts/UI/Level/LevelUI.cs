using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.Level
{
    public class LevelUi : MonoBehaviour
    {
        public Image LevelIcon;
        public Text LevelText;
        public Text LevelPercentText;

        public class Factory : PlaceholderFactory<LevelUi> { }
    }
}
