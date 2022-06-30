using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;
    public GameObject loadingPanel;
    public float minLoadTime;

    public Image fadeImage;
    public float fadeTime;

    private string targetScene;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        loadingPanel.SetActive(false);
        fadeImage.gameObject.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        targetScene = sceneName;
        StartCoroutine(LoadSceneRoutine());
    }
    private IEnumerator LoadSceneRoutine()
    {

        fadeImage.gameObject.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0);

        while (!Fade(1))
        {
            yield return null;
        }

        loadingPanel.SetActive(true);
        while (!Fade(0))
        {
            yield return null;
        }

        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);
        float elapsedLoadTime = 0f;
        while (!op.isDone)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return op;
        }
        while (elapsedLoadTime < minLoadTime)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }
        while (!Fade(1))
        {
            yield return null;
        }
        loadingPanel.SetActive(false);
        while (!Fade(0))
        {
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
    }
    private bool Fade(float target)
    {
        fadeImage.CrossFadeAlpha(target, fadeTime, true);

        if (Mathf.Abs(fadeImage.canvasRenderer.GetAlpha() - target) <= 0.05f)
        {
            fadeImage.canvasRenderer.SetAlpha(target);
            return true;
        }
        return false;
    }
}