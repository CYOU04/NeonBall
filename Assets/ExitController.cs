using UnityEngine;

public class ExitController : MonoBehaviour
{
    public static bool beShot;

    private void Start()
    {

    }

    private void Update()
    {
        if (beShot == true)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if (beShot == false)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
