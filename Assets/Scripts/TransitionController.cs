using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    public static TransitionController Instance;

    public CanvasGroup CanvasGroup;
    private float FadeSpeed = 1.5f;

    private bool isTransitioning = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ResetUI();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void ResetUI()
    {
        if (CanvasGroup != null)
        {
            CanvasGroup.alpha = 0;
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
        }
    }
    // void Start()
    // {
    //     if (CanvasGroup != null)
    //     {
    //         CanvasGroup.alpha = 0;
    //         CanvasGroup.interactable = false;
    //         CanvasGroup.blocksRaycasts = false;
    //     }
    // }
    public void LoadSceneWithFade(string SceneName)
    {
        if (isTransitioning)
        {
            return;
        }
        StartCoroutine(TransitionRoutine(SceneName));
    }
    IEnumerator TransitionRoutine(string SceneName)
    {
        isTransitioning = true;

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
        yield return new WaitForSeconds(0.1f);
        while (CanvasGroup.alpha > 0f)
        {
            CanvasGroup.alpha -= Time.deltaTime * FadeSpeed;
            yield return null;
        }

        ResetUI();
        isTransitioning = false;
    }
    void Update()
    {
        
    }
}
