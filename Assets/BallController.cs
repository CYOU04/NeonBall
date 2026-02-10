using UnityEngine;
using UnityEngine.UIElements;

public class BallController : MonoBehaviour
{
    private float SpringForce = 10f;


    private Rigidbody2D Rigidbody2D;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Circle"))
        {
            Vector2 HitPoint = other.contacts[0].point;
            Vector2 CenterPoint = (Vector2)other.transform.position;

            Vector2 SpringDirection = (CenterPoint - HitPoint).normalized;

            Rigidbody2D.AddForce(SpringDirection *  SpringForce, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        
    }
}
