using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Atom : MonoBehaviour {

    public int? P { get { return p; } }
    public LinkArranger Arranger { get { return arranger; } }
    public GameObject atom;

    private SphereCollider collider;
    private LinkArranger arranger;
    //private System.Random random;
    private Rigidbody rigidbody;
    private int? p;

    private bool moving;

    // Start is called before the first frame update
    void Start() {

        p = 0;
        //random = new System.Random();
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<SphereCollider>();
        arranger = GetComponentInChildren<LinkArranger>();

        moving = true;
    }

    void FixedUpdate() {

        if (moving) {

            Vector3 direction = -(atom.transform.position - transform.position).normalized;
            this.transform.position += -direction * Time.deltaTime * 20;
            //rigidbody.MovePosition(transform.position - direction * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider collider) {
    
        Atom atom = collider.gameObject.GetComponent<Atom>();
        if (atom != null && arranger.HasEmptyLinks && atom.Arranger.HasEmptyLinks) {
            System.Random random = new System.Random();
            p = random.Next();
            while (p == atom.P) p = random.Next();
            if (p > atom.P) {
                Debug.Log($"{name} linked with {atom.name}");
                p = null;
                arranger.Link(atom.transform);
                atom.RotateTowards(transform);
            }
            p = null;
            moving = false;
        }
    }

    void RotateTowards(Transform targetTransform) {

        int index = arranger.GetEmptyLinkIndex();
        Transform linkTransform = arranger.LinkPositions[index];
        Vector3 targetDir = targetTransform.position - transform.position;
        Vector3 toDir = linkTransform.position - transform.position;
        float angle = Vector3.SignedAngle(targetDir, toDir, Vector3.up);
        this.transform.Rotate(Vector3.up, angle);

        arranger.SetLinkAtIndex(index, targetTransform);
    }
}
