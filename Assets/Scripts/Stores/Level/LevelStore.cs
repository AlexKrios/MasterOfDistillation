using Scripts.Objects;
using Scripts.UI.Level;
using System.Collections.Generic;
using Zenject;

namespace Scripts.Stores.Level
{
    public class LevelStore : ILevelStore
    {
        [Inject] private ILevelUIController _levelUIController;

        private List<LevelExperienceObject> _levelsExperience;
        public List<LevelExperienceObject> LevelsExperience
        {
            get { return _levelsExperience; }
            set { _levelsExperience = value; }
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
        
        private float _currentExperience;
        public float CurrentExperience
        {
            get { return _currentExperience; }
            set 
            { 
                _currentExperience = value;
                _levelUIController.OnSetLevelPercent.Invoke();

                if (_currentExperience < _levelExperience)
                {
                    return;
                }

                _currentExperience -= _levelExperience;
                Level++;
            }
        }

        private float _levelExperience;
        public float LevelExperience
        {
            get { return _levelExperience; }
            set { _levelExperience = value; }
        }        
    }
}