using UnityEngine;

namespace Scripts.Scenes.Village.Buildings.MainCamera
{
    public class CameraController : ICameraController 
    {
        public Camera MainCamera { get; }

        public CameraController(Camera mainCamera)
        {
            MainCamera = mainCamera;
        }
    }
}
