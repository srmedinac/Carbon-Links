using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakForce : MonoBehaviour
{
    public ParticleType type;
    public static float STRENGTH = 0.05f, MAX_MAGNITUDE = 20f;

    private Transform[] attractors;
    private Rigidbody rigidbody;
    private Orbital parent;

    private float initialForce;

    // Start is called before the first frame update
    void Start() {

        parent = GetComponentInParent<Orbital>();
        rigidbody = GetComponent<Rigidbody>();

        Nucleus nucleus = FindObjectOfType<Nucleus>();
        attractors = nucleus.Protons;

        initialForce = parent.type == OrbitalType.HIGH ? 60f : 35f;

        Vector3 dir = (nucleus.transform.position - transform.position).normalized;
        Vector3 force = Vector3.Cross(dir, Vector3.up).normalized;
        rigidbody.AddForce(force * initialForce);
    }

    // Update is called once per frame
    void Update() {

        foreach (var attractedTo in attractors) {
            Vector3 direction = attractedTo.position - transform.position;
            rigidbody.AddForce(STRENGTH * direction);

            if (rigidbody.velocity.magnitude > MAX_MAGNITUDE) {
                rigidbody.velocity = rigidbody.velocity.normalized * MAX_MAGNITUDE;
            }
        }
    }
}
