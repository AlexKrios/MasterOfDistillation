using Scripts.Stores.Level;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Level
{
    public class LevelUIController : ILevelUIController
    {
        [Inject] private IUiController _uiController;
        [Inject] private ILevelStore _levelStore;

        private Text _levelText;
        private Text _levelPercentText;

        public UnityEvent OnSetLevelText { get; set; } = new UnityEvent();
        public UnityEvent OnSetLevelExperience { get; set; } = new UnityEvent();
        public UnityEvent OnSetLevelPercent { get; set; } = new UnityEvent();

        public LevelUIController()
        {
            OnSetLevelText.AddListener(SetLevelText);
            OnSetLevelExperience.AddListener(SetLevelExperience);
            OnSetLevelPercent.AddListener(SetLevelPercent);
        }

        private void SetLevelText()
        {            
            if (!_levelText)
            {
                _levelText = _uiController.Find("Level").GetComponent<LevelUI>().LevelText;
            }

            _levelText.text = _levelStore.Level.ToString();
        }

        private void SetLevelExperience()
        {
            var _level = _levelStore.Level;
            var _levelsExpirience = _levelStore.LevelCaps;

            _levelStore.LevelCap = _levelsExpirience[_level - 1].Max;
        }

        private void SetLevelPercent()
        {
            var _curExpirience = _levelStore.Experience;
            var _levelExpirience = _levelStore.LevelCap;

            var levelPercent = _curExpirience / (_levelExpirience / 100);

            if (!_levelPercentText) 
            {
                _levelPercentText = _uiController.Find("Level").GetComponent<LevelUI>().LevelPercentText;
            }

            _levelPercentText.text = string.Format("{0:f0}%", levelPercent);
        }
    }
}
