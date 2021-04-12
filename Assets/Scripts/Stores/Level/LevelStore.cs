using Scripts.Objects;
using Scripts.UI.Level;
using System.Collections.Generic;
using Zenject;

namespace Scripts.Stores.Level
{
    public class LevelStore : ILevelStore
    {
        [Inject] private ILevelUIController _levelUIController;

        private List<LevelExperienceObject> _experienceMax;
        public List<LevelExperienceObject> ExperienceMax
        {
            get { return _experienceMax; }
            set { _experienceMax = value; }
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

                if (_experience < _experienceCap)
                {
                    return;
                }

                _experience -= _experienceCap;
                Level++;
            }
        }

        private float _experienceCap;
        public float ExperienceCap
        {
            get { return _experienceCap; }
            set { _experienceCap = value; }
        }        
    }
}