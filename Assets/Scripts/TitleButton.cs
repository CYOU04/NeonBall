using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
