using UnityEngine;

public class OuterCircleController : MonoBehaviour
{
    private float RotationSpeed = 100f;
    private float Direction;
    private Rigidbody2D Rigidbody2D;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Direction = -RotateController.Direction;
    }
    private void FixedUpdate()
    {
        float NewAngle = Rigidbody2D.rotation + (RotationSpeed * Time.fixedDeltaTime * Direction);
        Rigidbody2D.MoveRotation(NewAngle);
    }
}
