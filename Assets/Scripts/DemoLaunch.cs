using UnityEngine;

public class DemoLaunch : MonoBehaviour
{
    public GameObject BallPrefab;
    public Transform SpawnPoint;
    private float LaunchForce = 10f;
    private GameObject CurrentBall;

    void Start()
    {
        TrySpawn();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TrySpawn();
        }
    }
    void TrySpawn()
    {
        if (CurrentBall == null)
        {
            SpawnBall();
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