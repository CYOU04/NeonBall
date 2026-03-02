using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnButtonClick()
    {
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
