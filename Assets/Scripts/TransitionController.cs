using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    public static TransitionController Instance;

    public CanvasGroup CanvasGroup;
    private float FadeSpeed = 1.5f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        if (CanvasGroup != null)
        {
            CanvasGroup.alpha = 0;
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
        }
    }
    public void LoadSceneWithFade(string SceneName)
    {
        StartCoroutine(TransitionRoutine(SceneName));
    }
    IEnumerator TransitionRoutine(string SceneName)
    {
        CanvasGroup.blocksRaycasts = true;
        while (CanvasGroup.alpha < 1f)
        {
            CanvasGroup.alpha += Time.deltaTime * FadeSpeed;
            yield return null;
        }
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        while (CanvasGroup.alpha > 0f)
        {
            CanvasGroup.alpha -= Time.deltaTime * FadeSpeed;
            yield return null;
        }

        CanvasGroup.blocksRaycasts = false;
        CanvasGroup.interactable = false;
    }
    void Update()
    {
        
    }
}
