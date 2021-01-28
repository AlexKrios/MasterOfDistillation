using System.Collections;
using UnityEngine;

namespace Scripts.Scenes.Village.Buildings.Production
{
    public abstract class AbstractProduction : MonoBehaviour, IProduction
    {
        //public void StartProduction()
        //{
        //    StartCoroutine(ProductionLogic());
        //}

        public virtual IEnumerator StartProduction()
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
