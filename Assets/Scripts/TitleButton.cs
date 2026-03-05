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
