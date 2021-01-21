using Scripts.UI.Gold;
using Scripts.UI.Level;
using UnityEngine;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;        

        public InitManager initManager;

        [Header("Level")]
        public LevelManager levelManager;

        [Header("Resources")]
        public GoldManager goldManager;        

        [Header("Camera")]
        public Camera mainCamera;

        [Header("Constants")]
        [Range(1, 5)] public float moveSpeed = 1;
        [Range(1, 5)] public float rotateSpeed = 1;
        [Range(1, 5)] public float zoomSpeed = 1;

        private void Start()
        {
            Instance = this;
        }
    }
}
