using Scripts.Common.Craft;
using Scripts.Timer;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop.Craft
{
    public class CraftMenuCreateUI : MonoBehaviour
    {
        [Inject] private IUiController _uiController;

        private Transform _sceneContext;

        [Inject]
        private void Construct([Inject(Id = "SceneContext")] Transform sceneContext)
        {
            _sceneContext = sceneContext;
        }

        private void Start() { }

        public void StartProduction()
        {
            _uiController.ActiveBuilding.GetComponent<ICraft>().CraftProduct();
        }

        public void StartRawTimer()
        {
            _sceneContext.GetComponent<ITimerController>().SetRawTimers();
        }
    }
}
