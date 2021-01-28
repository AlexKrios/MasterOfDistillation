using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts.UI.Gold
{
    public class GoldManager : MonoBehaviour, IGoldManager
    {
        private int _gold;
        public int Gold 
        {
            get { return _gold; } 
            set
            {
                _gold = value;
                SetGoldText();
            } 
        }

        private GameObject _goldGameObject;
        private Text _goldText;

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

            _goldGameObject = GameObject.Find("MainCanvas").transform.Find("Gold").gameObject;
        }

        private void SetGoldText() 
        {
            if (_goldText == null)
            {
                _goldText = _goldGameObject.transform.Find("Count").GetComponent<Text>();
            }

            _goldText.text = _gold.ToString(); 
        }
    }
}
