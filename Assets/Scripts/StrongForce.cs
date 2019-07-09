using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StrongForce : MonoBehaviour {

    public ParticleType type;
    public static float STRENGTH = 20f, MAX_MAGNITUDE = 20f;

    private Transform[] attractors;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start() {

        rigidbody = GetComponent<Rigidbody>();
        Nucleus nucleus = FindObjectOfType<Nucleus>();
        attractors = this.type == ParticleType.PROTON ? nucleus.Neutrons : nucleus.Protons;
    }

    // Update is called once per frame
    void Update() {

        foreach(var attractedTo in attractors) {
            Vector3 direction = attractedTo.position - transform.position;
            rigidbody.AddForce(STRENGTH * direction);

            if (rigidbody.velocity.magnitude > MAX_MAGNITUDE) {
                rigidbody.velocity = rigidbody.velocity.normalized * MAX_MAGNITUDE;
            }
        }
    }
}
