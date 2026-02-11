using UnityEngine;

public class OuterCircleController : MonoBehaviour
{
    private float RotationSpeed = -100f;
    private Rigidbody2D Rigidbody2D;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float NewAngle = Rigidbody2D.rotation + RotationSpeed * Time.fixedDeltaTime;
        Rigidbody2D.MoveRotation(NewAngle);
    }
    void Update()
    {

    }
}
