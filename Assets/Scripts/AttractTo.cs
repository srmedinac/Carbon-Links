using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractTo : MonoBehaviour{

    public Transform attractedTo;
    public float strengthOfAttraction, maximumMagnitude;
    private Rigidbody rigidbody;

    void Start(){

        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){

        if(attractedTo != null) {
            Vector3 direction = attractedTo.position - transform.position;
            rigidbody.AddForce(strengthOfAttraction * direction);

            if(rigidbody.velocity.magnitude > maximumMagnitude) {
                rigidbody.velocity = rigidbody.velocity.normalized * maximumMagnitude;
            }
        }
    }
}
