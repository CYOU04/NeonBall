using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public GameObject BallPrefab;
    public Transform SpawnPoint;
    private float LaunchForce = 10f;
    private GameObject CurrentBall;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TrySpawnBall();
        }
    }
    void TrySpawnBall()
    {
        if (CurrentBall == null)
        {
            SpawnBall();
        }
        else
        {
            Debug.Log("Ball already exists.");
        }
    }
    void SpawnBall()
    {
        CurrentBall = Instantiate(BallPrefab, SpawnPoint.position, Quaternion.identity);

        Rigidbody2D Rigidbody2D = CurrentBall.GetComponent<Rigidbody2D>();

        if (Rigidbody2D != null)
        {
            Rigidbody2D.AddForce(SpawnPoint.up * LaunchForce, ForceMode2D.Impulse);
        }
    }
}
