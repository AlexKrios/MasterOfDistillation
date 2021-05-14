using Assets.Scripts.Stores.Level;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.Level
{
    public class LevelUiController : ILevelUiController
    {
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly ILevelStore _levelStore;

        private Text _levelText;
        private Text _levelPercentText;

        public UnityEvent OnSetLevelText { get; set; }
        public UnityEvent OnSetLevelExperience { get; set; }
        public UnityEvent OnSetLevelPercent { get; set; }

        public LevelUiController()
        {
            OnSetLevelText = new UnityEvent();
            OnSetLevelExperience = new UnityEvent();
            OnSetLevelPercent  = new UnityEvent();

        OnSetLevelText.AddListener(SetLevelText);
            OnSetLevelExperience.AddListener(SetLevelExperience);
            OnSetLevelPercent.AddListener(SetLevelPercent);
        }

        private void SetLevelText()
        {            
            if (!_levelText)
            {
                _levelText = _uiController.Find("Level").GetComponent<LevelUi>().LevelText;
            }

            _levelText.text = _levelStore.Level.ToString();
        }

        private void SetLevelExperience()
        {
            var level = _levelStore.Level;
            var levelsExperience = _levelStore.LevelCaps;

            _levelStore.LevelCap = levelsExperience[level - 1];
        }

        private void SetLevelPercent()
        {
            var curExperience = _levelStore.Experience;
            var levelExperience = _levelStore.LevelCap;

            var levelPercent = curExperience / (levelExperience / 100);

            if (!_levelPercentText) 
            {
                _levelPercentText = _uiController.Find("Level").GetComponent<LevelUi>().LevelPercentText;
            }

            _levelPercentText.text = $"{levelPercent:f0}%";
        }
    }
}
