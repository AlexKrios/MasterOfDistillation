using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Timer.Raw 
{
    public interface IRawTimerController
    {
        Dictionary<string, Coroutine> RawTimers { get; set; }
        IEnumerator RawTimerExecute(string type);
    }
}
