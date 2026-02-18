using UnityEngine;
using UnityEngine.UI;

public class ShootingCooldown : MonoBehaviour
{
    public static ShootingCooldown Instance;

    public Slider Slider;
    private float RecoverySpeed = 1f;
    void Start()
    {

    }

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // if (LauncherController.BallExist == false)
        // {
        //     Slider.value = 0f;
        //     return;
        // }
        if (Slider.value < 1f)
        {
            Slider.value += RecoverySpeed * Time.deltaTime;
        }
    }
}
