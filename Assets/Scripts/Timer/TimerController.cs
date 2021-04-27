﻿using Scripts.Stores.Raw;
using Scripts.Timer.Raw;
using UnityEngine;
using Zenject;

namespace Scripts.Timer
{
    public class TimerController : MonoBehaviour, ITimerController
    {
        [Inject] private IRawStore _rawStore;
        [Inject] private IRawTimerController _rawTimerController;

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
