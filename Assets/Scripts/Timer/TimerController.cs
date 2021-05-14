using Assets.Scripts.Stores.Raw;
using Assets.Scripts.Timer.Raw;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Timer
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
                if (_rawTimerController.RawTimers.ContainsKey(raw.Value.Data.Name))
                {
                    return;
                }

                _rawTimerController.RawTimers.Add(
                    raw.Value.Data.Name, 
                    StartCoroutine(_rawTimerController.RawTimerExecute(raw.Value.Data.Name))
                );
            }
        }
    }
}
