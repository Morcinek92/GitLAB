using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]       // Widoczność w unity "Granica"
public class Granica
{   // Prędkość = 10; Xmin = -11; Xmax= 11; Zmin= 2,5; Zmax= 8; Przechylenie = 3;
    public float xmin, xmax, zmin, zmax;

}

public class PlayerController : MonoBehaviour
{
    public float Predkosc;
    public float Przechylenie;
    public Granica granica;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Jump") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);        
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        Rigidbody rb = GetComponent<Rigidbody>();  // pobieranie komponentu velocity, position itp. 

        rb.velocity = movement * Predkosc;   // kierowanie statkiem oraz zwiększenie prędkośći 

        rb.position = new Vector3
        (
            // Mathf.Clamp - ztrzaskuje wartość pomiedzy min i max.
            Mathf.Clamp (rb.position.x, granica.xmin, granica.xmax), 
            0.0f, 
            Mathf.Clamp (rb. position.z, granica.zmin, granica.zmax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -Przechylenie);
    }


}
