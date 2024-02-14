using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    public float damage = 10f;

    [SerializeField]
    public float range = 100f;

    [SerializeField]
    public Camera fpsCam;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
   



}
