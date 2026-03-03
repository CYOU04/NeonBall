using UnityEngine;
using TMPro;

public class LanguageSwitcher : MonoBehaviour
{
    public static bool isEnglish = true;
    public TextMeshProUGUI LanguageText;

    void Start()
    {
        UpdateLabel();
    }
    void UpdateLabel()
    {
        LanguageText.text = isEnglish ? "EN" : "JP";
    }

    void Update()
    {

    }
    public void OnButtonClick()
    {
        isEnglish = !isEnglish;
        UpdateLabel();

        AboutText About = Object.FindFirstObjectByType<AboutText>();
        if (About != null)
        {
            About.RefreshContent();
        }
    }
}
