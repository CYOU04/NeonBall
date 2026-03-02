using UnityEngine;

public class NeonTrap : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    private float LerpSpeed = 1f;

    private readonly Color ColorA = new Color(0f, 0.9f, 1f);
    private readonly Color ColorB = new Color(1f, 0.1f, 0.8f);
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float Lerp = Mathf.PingPong(Time.time * LerpSpeed, 1f);
        SpriteRenderer.color = Color.Lerp(ColorA, ColorB, Lerp);
    }
}
