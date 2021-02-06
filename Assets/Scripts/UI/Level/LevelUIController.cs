using Scripts.Stores.Level;
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

        public void SetLevel(int value)
        {
            _levelStore.Level = value;
            SetLevelText();
        }

        private void PlusOneLevel()
        {
            _levelStore.Level++;
            SetLevelText();
        }

        private void SetLevelText()
        {            
            if (!_levelText)
            {
                _levelText = _uiController.Find("Level").GetComponent<LevelUI>().LevelText;
            }

            _levelText.text = _levelStore.Level.ToString();
        }

        public void SetCurrentExperience(int value)
        {
            _levelStore.CurrentExpirience = value;
        }

        public void PlusCurrentExperience(int value)
        {
            _levelStore.CurrentExpirience += value;
            CheckForNewLevel();
            SetLevelPercent();
        }

        private void CheckForNewLevel()
        {
            var _currentExpirience = _levelStore.CurrentExpirience;
            var _levelExpirience = _levelStore.LevelExpirience;

            if (_currentExpirience < _levelExpirience)
            {
                return;
            }

            _levelStore.CurrentExpirience -= _levelExpirience;
            PlusOneLevel();
            SetLevelExperience();            
        }

        public void SetLevelExperience()
        {
            var _level = _levelStore.Level;
            var _levelsExpirience = _levelStore.LevelsExpirience;

            _levelStore.LevelExpirience = _levelsExpirience[_level - 1].max;
        }

        public void SetLevelPercent()
        {
            var _curExpirience = _levelStore.CurrentExpirience;
            var _levelExpirience = _levelStore.LevelExpirience;

            var levelPercent = _curExpirience / (_levelExpirience / 100);

            if (!_levelPercentText) 
            {
                _levelPercentText = _uiController.Find("Level").GetComponent<LevelUI>().LevelPercentText;
            }

            _levelPercentText.text = string.Format("{0:f0}%", levelPercent);
        }
    }
}
