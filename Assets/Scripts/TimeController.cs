using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    public Slider Timer;
    private bool isEnding = false;

    void Start()
    {
        Timer.value = Timer.maxValue;
    }

    void Update()
    {
        if (isEnding == false)
        {
            if (Timer.value > 0)
            {
                Timer.value -= Time.deltaTime;
            }
            else
            {
                isEnding = true;

                ResultController.ResultText = "Time out";

                if (TransitionController.Instance != null)
                {
                    TransitionController.Instance.LoadSceneWithFade("GameOver");
                }
                else
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }
}