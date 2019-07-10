using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Atom : MonoBehaviour {

    public int? P { get; private set; }
    public LinkArranger Arranger { get; private set; }
    public Vector3 Movement { get; set; }
    public static int SPEED = 100;

    private new SphereCollider collider;
    private new Rigidbody rigidbody;
    private bool moving;

    // Start is called before the first frame update
    void Start() {

        P = 0;
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<SphereCollider>();
        Arranger = GetComponentInChildren<LinkArranger>();

        moving = true;
    }

    void FixedUpdate() {

        if (moving) {

            //Vector3 direction = -(Movement - transform.position).normalized;
            this.transform.position += Movement * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider collider) {
    
        Atom atom = collider.gameObject.GetComponent<Atom>();
        if (atom != null && Arranger.HasEmptyLinks && atom.Arranger.HasEmptyLinks) {
            System.Random random = new System.Random();
            P = random.Next();
            while (P == atom.P) P = random.Next();
            if (P > atom.P) {
                Debug.Log($"{name} linked with {atom.name}");
                P = null;
                Arranger.Link(atom.transform);
                atom.RotateTowards(transform);
            }
            P = null;
            moving = false;
            return;
        }

        GameObject col = collider.gameObject;
        if (col.CompareTag("Wall")){

            Transform wall = col.transform;
            float x = col.name.Equals("Right") || col.name.Equals("Left") ? -Movement.x : Movement.x;
            float y = col.name.Equals("Top") || col.name.Equals("Bottom") ? -Movement.y : Movement.y;
            float z = col.name.Equals("Back") || col.name.Equals("Front") ? -Movement.z : Movement.z;

            Movement = new Vector3(x,y,z);
        }
    }

    void RotateTowards(Transform targetTransform) {

        int index = Arranger.GetEmptyLinkIndex();
        Transform linkTransform = Arranger.LinkPositions[index];
        Vector3 targetDir = targetTransform.position - transform.position;
        Vector3 toDir = linkTransform.position - transform.position;
        float angle = Vector3.SignedAngle(targetDir, toDir, Vector3.up);
        this.transform.Rotate(Vector3.up, angle);

        Arranger.SetLinkAtIndex(index, targetTransform);
    }
}
