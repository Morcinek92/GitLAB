using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZniszczenieKontakt : MonoBehaviour
{
   public GameObject wybuch;
   public GameObject wybuchGracza;

   private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Granica")
        {
            return;
        }
        Instantiate(wybuch, transform.position, transform.rotation);

        if (other.tag == "Gracz")
        {
            Instantiate(wybuchGracza, other.transform.position, other.transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
