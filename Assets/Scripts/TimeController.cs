using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    public Slider Timer;
    private bool isEnding = false;

    private Color Color1 = new Color(0.5f, 0f, 0f);
    private Color Color2 = new Color(1f, 0.1f, 0.1f);
    public Image FillImage;

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
                UpdateVisuals();
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

    void UpdateVisuals()
    {
        if (FillImage == null)
        {
            return;
        }


        float Ratio = Timer.value / Timer.maxValue;

        FillImage.color = Color.Lerp(Color2, Color1, Ratio);

        if (Ratio < 0.25f)
        {
            float Blink = Mathf.PingPong(Time.time * 8f, 1f);
            FillImage.color = Color.Lerp(Color2, Color.white, Blink);
            Timer.transform.localScale = Vector3.one * (1f + Blink * 0.05f);
        }
        else
        {
            Timer.transform.localScale = Vector3.one;
        }
    }
}