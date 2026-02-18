using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    public Slider Timer;
    void Start()
    {
        Timer.value = Timer.maxValue;
    }

    void Update()
    {
        if (Timer.value > 0)
        {
            Timer.value -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}