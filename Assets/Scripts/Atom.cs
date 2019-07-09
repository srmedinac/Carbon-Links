using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour {

    private SphereCollider collider;

    // Start is called before the first frame update
    void Start() {

        collider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider collider) {

        string name = collider.gameObject.name;
        if(!string.IsNullOrEmpty(name)) Debug.Log(name);
    }
}
