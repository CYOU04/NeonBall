using UnityEngine;
using TMPro;
public class ResultController : MonoBehaviour
{
    public TextMeshProUGUI Result;
    public static string ResultText;
    void Start()
    {
        
    }

    void Update()
    {
        Result.text = ResultText;
    }
}
