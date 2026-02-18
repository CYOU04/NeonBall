using UnityEngine;
using System.Threading.Tasks;

public class LauncherController : MonoBehaviour
{
    public GameObject BallPrefab;
    public Transform SpawnPoint; 
    private float LaunchForce = 10f;
    private GameObject CurrentBall;

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
    }
    void SpawnBall()
    {
        CurrentBall = Instantiate(BallPrefab, SpawnPoint.position, Quaternion.identity);

        Rigidbody2D Rigidbody2D = CurrentBall.GetComponent<Rigidbody2D>();

        if (Rigidbody2D != null)
        {
            Rigidbody2D.AddForce(SpawnPoint.up * LaunchForce, ForceMode2D.Impulse);
        }
        BallExistSet();
    }
    private async void BallExistSet()
    {
        await Task.Delay(10);
        BallExist = true;
    }
}
