using Scripts.UI;
using Scripts.UI.Gold;
using Scripts.UI.Level;
using Scripts.UI.Vodka;
using System;
using UnityEngine;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [Header("Api")]
        public ApiManager apiManager;

        [Header("UI")]
        public UiManager uiManager;

        [Header("Level")]
        public LevelManager levelManager;

        [Header("Resources")]
        public GoldManager goldManager;
        public VodkaManager vodkaManager;

        [Header("Constants")]
        [Range(1, 5)] public float moveSpeed = 1;
        [Range(1, 5)] public float rotateSpeed = 1;
        [Range(1, 5)] public float zoomSpeed = 1;

        [NonSerialized] public string initData;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            Instance = this;

            //StartCoroutine(apiManager.loadData((string data) => initData = data));
        }
    }
}
