using System;
using System.Collections;

namespace Scripts.Api
{
    public interface IApiManager
    {
        IEnumerator LoadData(Action<string> finishDelegate);
    }
}
