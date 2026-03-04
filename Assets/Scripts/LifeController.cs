using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LifeController : MonoBehaviour
{
    public static float Life = 4;
    public TextMeshProUGUI LifeText;

    private bool isEnding = false;
    void Start()
    {
        Life = 4;
        isEnding = false;
    }

    void Update()
    {
        LifeText.text = Life.ToString();

        if (Life <= 0 && !isEnding)
        {
            isEnding = true;
            ResultController.ResultText = "Ball out";

            if (TransitionController.Instance != null)
            {
                TransitionController.Instance.LoadSceneWithFade("GameOver");
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
