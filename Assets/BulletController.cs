using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float Speed = 25f;
    private Rigidbody2D Rigidbody2D;

    public GameObject DeadBall;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.linearVelocity = transform.up * Speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ExitController.beShot = true;

        Debug.Log("Exit actived");
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Circle"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Ball"))
        {
            Vector2 DeadBallPosition = other.gameObject.transform.position;
            Vector3 DeadBallSpawnPosition = new Vector3(DeadBallPosition.x, DeadBallPosition.y, 0f);
            Instantiate(DeadBall, DeadBallSpawnPosition, Quaternion.identity);

            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("Ball destroyed");
            LauncherController.BallExist = false;
        }
        if (other.gameObject.CompareTag("DeadBall"))
        {
            Destroy(gameObject);
        }
    }
}
