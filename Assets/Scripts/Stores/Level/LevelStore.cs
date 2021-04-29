using Scripts.Objects;
using Scripts.UI.Level;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Stores.Level
{
    public class LevelStore : ILevelStore
    {
        [Inject] private ILevelUIController _levelUIController;

        private List<LevelCaps> _levelCaps;
        public List<LevelCaps> LevelCaps
        {
            get { return _levelCaps; }
            set { _levelCaps = value; }
        }

        private LevelObject _levelInfo;
        public LevelObject LevelInfo 
        {
            get { return _levelInfo; }
            set 
            {
                _levelInfo = value;

                Level = _levelInfo.Level;
                Experience = _levelInfo.Experience;
            }
        }        

        private int _level;
        public int Level
        {
            get { return _level; }
            set 
            { 
                _level = value;
                _levelUIController.OnSetLevelText.Invoke();
                _levelUIController.OnSetLevelExperience.Invoke();
                _levelUIController.OnSetLevelPercent.Invoke();
            }
        }        
        
        private float _experience;
        public float Experience
        {
            get { return _experience; }
            set 
            { 
                _experience = value;
                _levelUIController.OnSetLevelPercent.Invoke();

                if (_experience < _levelCap)
                {
                    return;
                }

                _experience -= _levelCap;
                Level++;
            }
        }

        private float _levelCap;
        public float LevelCap
        {
            get { return _levelCap; }
            set { _levelCap = value; }
        }

        public LevelStore()
        {
            var levelSettings = Resources.Load("Data/Level/Settings") as LevelSettings;

            _levelCaps = levelSettings.Caps;
        }
    }
}