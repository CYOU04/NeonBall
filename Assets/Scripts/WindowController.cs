using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindowController : MonoBehaviour
{
    public static bool isFullScreen;
    public TextMeshProUGUI Resolution;
    void Start()
    {
        if (Screen.fullScreen)
        {
            isFullScreen = true;
        }
        else
        {
            isFullScreen = false;
        }
    }
    public void ToggleScreen()
    {
        if (Screen.fullScreen)
        {
            isFullScreen = false;
            Screen.SetResolution(1280, 720, false);
        }
        else
        {
            isFullScreen = true;
            Resolution maxRes = Screen.currentResolution;
            Screen.SetResolution(maxRes.width, maxRes.height, FullScreenMode.FullScreenWindow);
        }
    }
    void Update()
    {
        if (WindowController.isFullScreen == true)
        {
            Resolution.text = "Full Screen";
        }
        else
        {
            Resolution.text = "1280 * 720";
        }
    }
}
