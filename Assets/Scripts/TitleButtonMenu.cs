using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnButtonClick()
    {
        Time.timeScale = 1;
        MenuManager.isPaused = false;
        SceneManager.LoadScene("Title");
    }
}
