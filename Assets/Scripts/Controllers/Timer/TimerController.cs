using Assets.Scripts.Controllers.Timer.Raw;
using Assets.Scripts.Stores.Raw;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Controllers.Timer
{
    public class TimerController : MonoBehaviour, ITimerController
    {
        [Inject] private readonly IRawStore _rawStore;
        [Inject] private readonly IRawTimerController _rawTimerController;

        // ReSharper disable once UnusedMember.Local
        private void Start() { }

        public void SetRawTimers()
        {
            foreach (var raw in _rawStore.RawData)
            {                
                if (_rawTimerController.RawTimers.ContainsKey(raw.Value.Name))
                    return;

                _rawTimerController.RawTimers.Add(
                    raw.Value.Name, 
                    StartCoroutine(_rawTimerController.RawTimerExecute(raw.Value.Name))
                );
            }
        }
    }
}
