using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private bool isStarting = false;
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
        if (isStarting == true)
        {
            return;
        }
        isStarting = true;
        
        LauncherController.BallExist = false;
        LifeController.Life = 4;
        ResultController.ResultText = "";

        if (TransitionController.Instance != null)
        {
            TransitionController.Instance.LoadSceneWithFade("Stage");
        }
        else
        {
            SceneManager.LoadScene("Stage");
        }
    }
}
