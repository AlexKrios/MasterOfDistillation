using System;
using System.Collections;

namespace Assets.Scripts.Api
{
    public interface IApiManager
    {
        IEnumerator LoadData(Action<string> finishDelegate);
    }
}
