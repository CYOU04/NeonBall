using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LifeController : MonoBehaviour
{
    public static float Life = 4;
    public TextMeshProUGUI LifeText;
    void Start()
    {
        
    }

    void Update()
    {
        LifeText.text = Life.ToString();
        if (Life <= 0)
        {
            SceneManager.LoadScene("GameOver");
            ResultController.ResultText = "Ball out";
        }
    }
}
