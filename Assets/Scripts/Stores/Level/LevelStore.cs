using Assets.Scripts.Objects.Level;
using Assets.Scripts.Scriptable;
using Assets.Scripts.Ui;
using Assets.Scripts.Ui.Level;
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Stores.Level
{
    [UsedImplicitly]
    public class LevelStore : ILevelStore
    {
        [Inject] private readonly IUiController _uiController;

        public InitLevelEvent OnInitLevel { get; }
        public SetExperienceEvent OnSetExperience { get; }

        private Text _levelText;
        private Text _percentText;

        private readonly List<int> _levelCaps;
        private int _level;
        private float _experience;
        private float _levelCap;

        public LevelStore()
        {
            if (Resources.Load("Data/Level/Caps") is LevelCapsScriptable levelSettings)
            {
                _levelCaps = levelSettings.Caps;
            }

            OnInitLevel = new InitLevelEvent();
            OnInitLevel.AddListener(SetInitData);

            OnSetExperience = new SetExperienceEvent();
            OnSetExperience.AddListener(SetExperience);
        }

        private void SetInitData(LevelObject obj)
        {
            SetLevel(obj.Level);
            SetExperience(obj.Experience);
        }

        private void SetLevel(int level)
        {
            _level = level;

            if (!_levelText)
            {
                _levelText = _uiController.Find("Level").GetComponent<LevelUi>().LevelText;
            }

            SetLevelCap();

            _levelText.text = _level.ToString();
        }

        private void SetExperience(int experience)
        {
            _experience += experience;

            if (_experience >= _levelCap)
            {
                _experience -= _levelCap;
                SetLevel(_level + 1);
            }

            SetPercent();
        }

        private void SetLevelCap()
        {
            _levelCap = _levelCaps[_level - 1];
        }

        private void SetPercent()
        {
            var levelPercent = _experience / (_levelCap / 100);

            if (!_percentText)
            {
                _percentText = _uiController.Find("Level").GetComponent<LevelUi>().LevelPercentText;
            }

            _percentText.text = $"{levelPercent:f0}%";
        }
    }

    public class InitLevelEvent : UnityEvent<LevelObject> { }
    public class SetExperienceEvent : UnityEvent<int> { }
}