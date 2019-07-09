using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbital : MonoBehaviour
{
    [Range(0.1f,9.99f)]
    public float radius;
    public OrbitalType type;

    void OnDrawGizmosSelected() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

public enum OrbitalType { 
    HIGH,
    LOW
}
