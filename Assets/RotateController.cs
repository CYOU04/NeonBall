using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    private float TorqueAmount = 10f;
    private float MaxAngularVelocity = 100f;
    private Rigidbody2D Rigidbody2D;
    void Start()
    {
        Application.targetFrameRate = 60;

        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float input = Input.GetAxis("Horizontal");

        if (input != 0)
        {
            Rigidbody2D.AddTorque(-input *  TorqueAmount);
        }
        if (Mathf.Abs(Rigidbody2D.angularVelocity) > MaxAngularVelocity)
        {
            Rigidbody2D.angularVelocity = Mathf.Sign(Rigidbody2D.angularVelocity) * MaxAngularVelocity;
        }
    }
    void Update()
    {

    }
}
