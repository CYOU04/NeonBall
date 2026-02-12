using UnityEngine;

public class RotateController : MonoBehaviour
{
    private float RotationSpeed = 100f;
    public static float Direction = 1f;
    private Rigidbody2D Rigidbody2D;
    void Start()
    {
        Application.targetFrameRate = 60;
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");

        if (Horizontal < 0 && ShootingCooldown.Instance.Slider.value == 1f && Direction != -1f)
        {
            Direction = -1f;
            ShootingCooldown.Instance.Slider.value = 0f;
        }
        if (Horizontal > 0 && ShootingCooldown.Instance.Slider.value == 1f && Direction != 1f)
        {
            Direction = 1f;
            ShootingCooldown.Instance.Slider.value = 0f;
        }
    }
    private void FixedUpdate()
    {
        float NewAngle = Rigidbody2D.rotation + (RotationSpeed * Time.fixedDeltaTime * Direction);
        Rigidbody2D.MoveRotation(NewAngle);
    }
}
