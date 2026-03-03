using UnityEngine;
using TMPro;
using System.Collections;

public class AboutText : MonoBehaviour
{
    private TextMeshProUGUI TextMesh;
    [TextArea(10, 20)] public string EnglishContent;
    public TMP_FontAsset EnglishFont;
    [TextArea(10, 20)] public string JapaneseContent;
    public TMP_FontAsset JapaneseFont;

    private float WaitSpeed = 0.005f;
    private Coroutine TypingCoroutine;

    void OnEnable()
    {
        TextMesh = GetComponent<TextMeshProUGUI>();
        RefreshContent();
    }
    public void RefreshContent()
    {
        if (TextMesh == null)
        {
            TextMesh = GetComponent<TextMeshProUGUI>();
        }

        if (TypingCoroutine != null)
        {
            StopCoroutine(TypingCoroutine);
        }

        TextMesh.font = LanguageSwitcher.isEnglish ? EnglishFont : JapaneseFont;

        string Content = LanguageSwitcher.isEnglish ? EnglishContent : JapaneseContent;
        TypingCoroutine = StartCoroutine(TypeText(Content));
    }
    IEnumerator TypeText(string Content)
    {
        TextMesh.text = "";
        foreach (char c in Content.ToCharArray())
        {
            TextMesh.text += c;
            yield return new WaitForSeconds(WaitSpeed);
        }
    }
}
