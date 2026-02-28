using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    private float LerpSpeed = 2f;
    private Color TargetColor;

    public static readonly Color Color4 = new Color(0.1f, 0.18f, 0.1f);
    public static readonly Color Color3 = new Color(0.18f, 0.16f, 0.1f);
    public static readonly Color Color2 = new Color(0.25f, 0.1f, 0.1f);
    public static readonly Color Color1 = new Color(0.1f, 0.02f, 0.02f);
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        TargetColor = Color4;
        SpriteRenderer.color = Color4;
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeController.Life == 4)
        {
            TargetColor = Color4;
        }
        else if (LifeController.Life == 3)
        {
            TargetColor = Color3;
        }
        else if (LifeController.Life == 2)
        {
            TargetColor = Color2;
        }
        else if (LifeController.Life == 1)
        {
            TargetColor = Color1;
        }
        else if (LifeController.Life == 0)
        {
            TargetColor = Color.gray;
        }
        SpriteRenderer.color = Color.Lerp(SpriteRenderer.color, TargetColor, Time.deltaTime * LerpSpeed);
    }
}
