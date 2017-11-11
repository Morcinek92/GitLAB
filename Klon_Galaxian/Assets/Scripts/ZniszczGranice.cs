using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZniszczGranice : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
