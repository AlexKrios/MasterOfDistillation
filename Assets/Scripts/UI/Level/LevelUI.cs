using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Level
{
    public class LevelUI : MonoBehaviour
    {
        public Image LevelIcon;
        public Text LevelText;
        public Text LevelPercentText;

        public class Factory : PlaceholderFactory<LevelUI> { }
    }
}
