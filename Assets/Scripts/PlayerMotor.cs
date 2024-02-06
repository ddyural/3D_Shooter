using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 velocity = Vector3.zero; // передвижение 
    private Vector3 rotation = Vector3.zero; // вращение    

    void Start ()
    {
        rb = GetComponent <Rigidbody> ();
    }

    public void Move (Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate (Vector3 _rotation)
    {
        rotation = _rotation;
    }

    void FixedUpdate ()
    {
        PerformMove();
        PerformRotation();
    }

    void PerformMove ()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation ()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler (rotation) ); // rb.rotation - вращение, которое стоит сейчас
    } // просто так вращать нельзя, нужно всё делать через Quaternion 

}
