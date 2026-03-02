using System.Collections;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public GameObject DeadBall;

    //private SpriteRenderer SpriteRenderer;
    //private float LerpSpeed = 2f;
    void Start()
    {
        //SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //float Lerp = Mathf.PingPong(Time.time * LerpSpeed, 1);
        //SpriteRenderer.color = Color.Lerp(Color.blue, Color.red, Lerp);
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
