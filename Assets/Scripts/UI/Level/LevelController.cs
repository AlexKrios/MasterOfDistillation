using Scripts.Objects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Level
{
    public class LevelController : ILevelController
    {
        private List<LevelExpObject> _levelsExpirience;
        public List<LevelExpObject> LevelsExpirience
        {
            get { return _levelsExpirience; }
            set { _levelsExpirience = value; }
        }

        private int _level;
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                SetLevelText();
            }
        }        
        
        private float _curExpirience;
        public float CurExpirience
        {
            get { return _curExpirience; }
            set
            {
                _curExpirience = value;

                if (_curExpirience >= _LevelExpirience)
                {
                    SetLevelUp();
                }

                SetLevelPercent();
            }
        }

        private float _LevelExpirience;
        public float LevelExpirience 
        {
            get { return _LevelExpirience; }
            set 
            {
                _LevelExpirience = value;
            }
        }        

        [SerializeField] private Text _levelText;
        [SerializeField] private Text _levelPercentText;

        public LevelController(Text levelText, Text levelPercentText)
        {
            _levelText = levelText;
            _levelPercentText = levelPercentText;
        }

        public void SetLevelExpirience() => LevelExpirience = _levelsExpirience[Level - 1].max;
        private void SetLevelUp()
        {
            _curExpirience -= _LevelExpirience;
            Level++;
            SetLevelExpirience();
        }
        
        private void SetLevelText() 
        {
            if (!_levelText) 
            {
                return;
            }

            _levelText.text = Level.ToString();
        }
        public void SetLevelPercent()
        {
            var levelPercent = _curExpirience / (_LevelExpirience / 100);
            _levelPercentText.text = string.Format("{0:f0}%", levelPercent);
        }
        public void SetExpirienceText() 
        {
            //_expirienceText.text = $"{_curExpirience} / {_LevelExpirience}";
        }
    }
}