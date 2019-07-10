using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakForce : MonoBehaviour
{
    public ParticleType type;
    public GameObject Nucleus;
    public static float STRENGTH = 10f, MAX_MAGNITUDE = 300f;
    public static float LOW_FORCE = 250f, HIGH_FORCE = 400f;

    private Transform[] attractors;
    private Rigidbody rigidbody;
    private Orbital parent;

    private float initialForce;

    // Start is called before the first frame update
    void Start() {

        parent = GetComponentInParent<Orbital>();
        rigidbody = GetComponent<Rigidbody>();

        Nucleus nucleus = Nucleus.GetComponent<Nucleus>();
        attractors = nucleus.Protons;

        initialForce = parent.type == OrbitalType.HIGH ? HIGH_FORCE : LOW_FORCE;

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
