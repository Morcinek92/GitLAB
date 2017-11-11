using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float Predkosc;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();  // pobieranie komponentu velocity, position itp. 

        rb.velocity = Vector3.forward * Predkosc;
    }
}
