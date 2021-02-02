using System.Collections;
using UnityEngine;
using Zenject;

namespace Scripts.Scenes.Village.Buildings.Production
{
    public abstract class AbstractProduction : MonoBehaviour
    {
        private IProductionController _productionController;

        [Inject]
        public void Construct(IProductionController productionController)
        {
            _productionController = productionController;
        }

        public void StartProduction()
        {
            var coroutine = StartCoroutine(Production());
            _productionController.Add("Test", coroutine);
        }

        public virtual IEnumerator Production()
        {
            var countdownValue = 10;

            var currCountdownValue = countdownValue;
            while (currCountdownValue > 0)
            {
                Debug.Log("Countdown: " + currCountdownValue);
                yield return new WaitForSeconds(1.0f);
                currCountdownValue--;
            }

            Debug.Log("Finish");
        }
    }
}
