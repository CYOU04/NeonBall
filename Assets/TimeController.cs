using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Slider Timer;
    void Start()
    {
        Timer.value = 60f;
    }

    void Update()
    {
        if (Timer.value > 0)
        {
            Timer.value -= Time.deltaTime;
        }
        else
        {

        }
    }
}