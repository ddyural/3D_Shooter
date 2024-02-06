using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSpeed = 100f;

    private PlayerMotor motor;

    void Start () 
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update ()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHor = transform.right * xMov;
        Vector3 movVer = transform.forward * zMov;

        Vector3 velocity = (movHor + movVer).normalized * speed;

        motor.Move (velocity);

        float yRot = Input.GetAxisRaw("Mouse X"); // y rotation 
        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSpeed;

        motor.Rotate(rotation);
    }
}
