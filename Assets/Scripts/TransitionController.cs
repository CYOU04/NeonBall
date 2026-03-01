using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    public CanvasGroup CanvasGroup;
    private float FadeSpeed = 1f;
    private bool isStarting = false;
    void Start()
    {
        if (CanvasGroup != null)
        {

            CanvasGroup.alpha = 0;
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
