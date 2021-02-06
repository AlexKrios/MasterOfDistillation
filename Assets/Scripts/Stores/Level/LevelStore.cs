using Scripts.Objects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Stores.Level
{
    public class LevelStore : ILevelStore
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
            set { _level = value; }
        }        
        
        private float _currentExpirience;
        public float CurrentExpirience
        {
            get { return _currentExpirience; }
            set { _currentExpirience = value; }
        }

        private float _levelExpirience;
        public float LevelExpirience 
        {
            get { return _levelExpirience; }
            set { _levelExpirience = value; }
        }        
    }
}