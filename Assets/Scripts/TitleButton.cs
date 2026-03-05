using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    private bool isClicked = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnButtonClick()
    {
        Debug.Log("Title Button Clicked");
        if (isClicked == true)
        {
            return;
        }
        isClicked = true;
        if (TransitionController.Instance != null)
        {
            TransitionController.Instance.LoadSceneWithFade("Title");
        }
        else
        {
            SceneManager.LoadScene("Title");
        }
    }
}
