using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSpeed = 3f;

    [SerializeField]
    private float minAngle = -90f; // Ограничение на вращение вверх

    [SerializeField]
    private float maxAngle = 90f; // Ограничение на вращение вниз

    private float xRot = 0f; // Переменная понадобится в дальнейшем.

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



        float xRot = Input.GetAxisRaw("Mouse Y") * lookSpeed; // Умножаем на lookSpeed здесь, чтобы учесть скорость вращения

        xRot = Mathf.Clamp(xRot, minAngle, maxAngle); // Применяем ограничение на вращение вверх и вниз

        Vector3 camRotation = new Vector3(xRot, 0f, 0f);

        motor.RotateCam(camRotation);
    }
}
