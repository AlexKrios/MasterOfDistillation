using UnityEngine;

namespace Scripts
{
    public class DestroyGameObject : MonoBehaviour
    {
        public static DestroyGameObject Instance;

        private void Start()
        {
            Instance = this;
        }

        public void Execute(GameObject gameObject)
        {
            Destroy(gameObject);
        }
    }
}
