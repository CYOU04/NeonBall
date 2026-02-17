using UnityEngine;

public class TrapController : MonoBehaviour
{
    public GameObject DeadBall;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Vector2 DeadBallPosition = other.gameObject.transform.position;
            Vector3 DeadBallSpawnPosition = new Vector3(DeadBallPosition.x, DeadBallPosition.y, 0f);
            Instantiate(DeadBall, DeadBallSpawnPosition, Quaternion.identity);

            Destroy(other.gameObject);
            Debug.Log("Ball destroyed");
            LauncherController.BallExist = false;
        }
    }
}
