using UnityEngine;
using System.Collections;

public class DeadBallController : MonoBehaviour
{
    private Color Color1 = new Color(0f, 1f, 1f, 1f);
    private SpriteRenderer SpriteRenderer;
    private float LertpSpeed = 1f;
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(LerpColorOnSpawn());
    }
    private IEnumerator LerpColorOnSpawn()
    {
        Color StartColor = SpriteRenderer.color;
        float ElapsedTime = 0f;
        while (ElapsedTime < LertpSpeed)
        {
            ElapsedTime += Time.deltaTime;
            float Time1 = ElapsedTime / LertpSpeed;
            SpriteRenderer.color = Color.Lerp(StartColor, Color1, Time1);
            yield return null;
        }
        SpriteRenderer.color = Color1;
    }
    void Update()
    {
        
    }
}