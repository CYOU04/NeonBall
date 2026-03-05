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
    private Coroutine CurrentTransition;

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
    public void ResetUI()
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
        CurrentTransition = StartCoroutine(TransitionRoutine(SceneName));
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
        yield return new WaitForEndOfFrame();
        while (CanvasGroup.alpha > 0f)
        {
            CanvasGroup.alpha -= Time.deltaTime * FadeSpeed;
            yield return null;
        }

        ResetUI();
        isTransitioning = false;
        CurrentTransition = null;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RemoveTransition();
        }
    }
    public void RemoveTransition()
    {
        if (CurrentTransition != null)
        {
            StopCoroutine(CurrentTransition);
            CurrentTransition = null;
        }
        ResetUI();
        isTransitioning = false;
        Debug.Log("Transition removed");
    }
}
