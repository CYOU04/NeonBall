using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float Speed = 25f;
    private Rigidbody2D Rigidbody2D;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.linearVelocity = transform.up * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Circle"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("Ball destroyed");
        }
    }
}
