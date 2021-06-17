using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.Timer.Raw 
{
    public interface IRawTimerController
    {
        Dictionary<string, Coroutine> RawTimers { get; set; }
        IEnumerator RawTimerExecute(string type);
    }
}
