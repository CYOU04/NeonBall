using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    private float SpringForce = 10f;
    private Rigidbody2D Rigidbody2D;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Circle"))
        {
            Vector2 HitPoint = other.contacts[0].point;
            Vector2 CenterPoint = (Vector2)other.transform.position;
            Vector2 SpringDirection = (CenterPoint - HitPoint).normalized;

            float RandomAngle = Random.Range(-15f, 15f);
            Vector2 FinalDirection = Quaternion.Euler(0, 0, RandomAngle) * SpringDirection;

            Rigidbody2D.linearVelocity = FinalDirection * SpringForce;
        }
        if (other.gameObject.CompareTag("DeadBall"))
        {
            Vector2 OutDirection = (transform.position - other.transform.position).normalized;
            Vector2 RandomDirection = Random.insideUnitCircle.normalized;

            if (Vector2.Dot(RandomDirection, OutDirection) < 0)
            {
                RandomDirection = -RandomDirection;
            }

            Rigidbody2D.linearVelocity = Vector2.zero;
            Rigidbody2D.linearVelocity = RandomDirection * SpringForce;
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Debug.Log("Completed!");
        LauncherController.BallExist = false;
        SceneManager.LoadScene("GameOver");
    }
}