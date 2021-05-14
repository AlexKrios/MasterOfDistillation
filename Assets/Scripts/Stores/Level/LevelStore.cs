using System.Collections.Generic;
using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Level;
using Assets.Scripts.UI.Level;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Stores.Level
{
    public class LevelStore : ILevelStore
    {
        [Inject] private readonly ILevelUiController _levelUiController;

        public List<int> LevelCaps { get; set; }

        private LevelObject _levelInfo;
        public LevelObject LevelInfo 
        {
            get => _levelInfo;
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
            get => _level;
            set 
            { 
                _level = value;
                _levelUiController.OnSetLevelText.Invoke();
                _levelUiController.OnSetLevelExperience.Invoke();
                _levelUiController.OnSetLevelPercent.Invoke();
            }
        }        
        
        private float _experience;
        public float Experience
        {
            get => _experience;
            set 
            { 
                _experience = value;
                _levelUiController.OnSetLevelPercent.Invoke();

                if (_experience < LevelCap)
                {
                    return;
                }

                _experience -= LevelCap;
                Level++;
            }
        }

        public float LevelCap { get; set; }

        public LevelStore()
        {
            if (Resources.Load("Data/Level/Caps") is LevelCapsScriptable levelSettings)
            {
                LevelCaps = levelSettings.Caps;
            }
        }
    }
}