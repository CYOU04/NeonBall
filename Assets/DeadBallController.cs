using UnityEngine;

public class DeadBallController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5f);
        Debug.Log(this.name + " destroyed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
