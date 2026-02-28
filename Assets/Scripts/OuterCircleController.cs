using UnityEngine;

public class OuterCircleController : MonoBehaviour
{
    private float RotationSpeed = 100f;
    private float Direction;
    private Rigidbody2D Rigidbody2D;

    private SpriteRenderer SpriteRenderer;
    private float LerpSpeed = 2f;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Direction = -RotateController.Direction;

        float Lerp = Mathf.PingPong(Time.time * LerpSpeed, 1);
        SpriteRenderer.color = Color.Lerp(Color.blue, Color.red, Lerp);
    }
    private void FixedUpdate()
    {
        float NewAngle = Rigidbody2D.rotation + (RotationSpeed * Time.fixedDeltaTime * Direction);
        Rigidbody2D.MoveRotation(NewAngle);
    }
}
