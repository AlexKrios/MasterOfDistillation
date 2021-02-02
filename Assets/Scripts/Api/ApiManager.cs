using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Scripts.Api
{
    public class ApiManager : IApiManager
    {
        private string _baseUrl = "http://localhost:8080/api";


        public void Test()
        {
            Debug.Log("Test");
        }

        public IEnumerator LoadData(Action<string> finishDelegate) 
        {
            var requestUrl = _baseUrl + "/admin/users";
            var request = UnityWebRequest.Get(requestUrl);

            yield return request.SendWebRequest();

            if (!request.isNetworkError && !request.isHttpError && request.isDone)
            {
                yield return request.downloadHandler.text;
            }            

            finishDelegate(request.downloadHandler.text);
        }
    }
}
