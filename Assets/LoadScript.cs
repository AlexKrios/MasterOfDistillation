using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets
{
    public class LoadScript : MonoBehaviour
    {
        public Slider ProgressBar;

        private AsyncOperation _loadingOperation;

        private bool _loading = true;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            StartCoroutine(LoadData(_ => _loading = false));
            StartCoroutine(StartLoad());
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            ProgressBar.value = Mathf.Clamp01(_loadingOperation.progress / 0.9f);
        }

        private IEnumerator StartLoad()
        {
            _loadingOperation = SceneManager.LoadSceneAsync(1);
            _loadingOperation.allowSceneActivation = false;
            while (_loading)
            {
                yield return null;
            }

            _loadingOperation.allowSceneActivation = true;
        }

        public IEnumerator LoadData(Action<string> finishDelegate)
        {
            var _baseUrl = "http://localhost:8080/api";
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
