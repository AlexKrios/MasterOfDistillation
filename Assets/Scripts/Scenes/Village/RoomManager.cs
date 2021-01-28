using Scripts.Scenes.Village.MainCamera;
using UnityEngine;

namespace Scripts.Scenes.Village
{
    public class RoomManager : MonoBehaviour
    {
        public static RoomManager Instance;

        [Header("Camera")]
        public Camera mainCamera;
        public Move move;
        public Zoom zoom;
        public Rotate rotate;
        public Target target;
        public Disable disable;

        [Header("UI")]
        public GameObject mainCanvas;

        private void Start()
        {
            Instance = this;
        }
    }
}
