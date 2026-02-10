using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public GameObject BallPrefab;
    public Transform SpawnPoint;
    private float LaunchForce = 10f;
    private GameObject CurrentBall;

    public GameObject BulletPrefab;

    public static bool BallExist;

    void Start()
    {
        
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
        else
        {
            if (ShootingCooldown.Instance.Slider.value == 1f)
            {
                SpawnBullet();
            }
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

        BallExist = true;
    }
    void SpawnBullet()
    {
        ShootingCooldown.Instance.Slider.value = 0f;
        Instantiate(BulletPrefab, SpawnPoint.position, transform.rotation);
    }
}
