using System.Collections;
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
            StartCoroutine(DeathTimer(other.gameObject));
        }
    }
    private IEnumerator DeathTimer(GameObject Ball)
    {
        yield return new WaitForSeconds(0.075f);

        if (Ball != null)
        {
            Vector2 DeadPosition = Ball.transform.position;
            Destroy(Ball);
            LifeController.Life -= 1;
            Instantiate(DeadBall, DeadPosition, Quaternion.identity);
            LauncherController.BallExist = false;
        }
    }
}
