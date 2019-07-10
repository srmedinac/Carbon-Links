using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nucleus : MonoBehaviour {


    public Transform[] protons = new Transform[6];
    public Transform[] Protons { get { return protons; } }

    public Transform[] neutrons = new Transform[6];
    public Transform[] Neutrons { get { return neutrons; } }
}
