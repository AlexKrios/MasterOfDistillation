using Scripts.Objects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts.UI.Level
{
    public class LevelManager : MonoBehaviour, ILevelManager
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

        private GameObject _levelGameObject;
        private Text _levelText;
        private Text _levelPercentText;     

        private void Start() { }
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }
        private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            if (scene.name != "Village") 
            {
                return;
            }

            _levelGameObject = GameObject.Find("MainCanvas").transform.Find("Level").gameObject;
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
            if (_levelText == null) 
            {
                _levelText = _levelGameObject.transform.Find("Icon/Count").GetComponent<Text>();                
            }

            _levelText.text = Level.ToString();
        }
        public void SetLevelPercent()
        {
            if (_levelPercentText == null)
            {
                _levelPercentText = _levelGameObject.transform.Find("Percent").GetComponent<Text>();
            }

            var levelPercent = _curExpirience / (_LevelExpirience / 100);
            _levelPercentText.text = string.Format("{0:f0}%", levelPercent);
        }
        public void SetExpirienceText() 
        {
            var _expirienceText = _levelGameObject.transform.Find("Expirience").GetComponent<Text>();
            _expirienceText.text = $"{_curExpirience} / {_LevelExpirience}";
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                CurExpirience += 50;
                Debug.Log($"{_curExpirience} / {_LevelExpirience}");
            }
        }
    }
}