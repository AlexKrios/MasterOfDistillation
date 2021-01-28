using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScript : MonoBehaviour
{
    public Slider progressBar;

    private AsyncOperation loadingOperation;

    private bool loading = true;

    private void Start()
    {
        StartCoroutine(loadData((string data) => loading = false));
        StartCoroutine(StartLoad());
    }

    private void Update()
    {
        progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
    }

    private IEnumerator StartLoad()
    {
        loadingOperation = SceneManager.LoadSceneAsync(1);
        loadingOperation.allowSceneActivation = false;
        while (loading)
        {
            yield return null;
        }

        loadingOperation.allowSceneActivation = true;
    }

    public IEnumerator loadData(Action<string> finishDelegate)
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
