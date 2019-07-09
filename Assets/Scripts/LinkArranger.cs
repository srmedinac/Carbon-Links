using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkArranger : MonoBehaviour
{
    public Transform[] Links { get { return links; } }
    public Transform[] LinkPositions { get { return linkPositions; } }

    private Transform[] links;
    private Transform[] linkPositions;

    void Start()
    {
        links = new Transform[4];
        linkPositions = new Transform[4];

        for (int i = 0; i < transform.childCount; i++) linkPositions[i] = transform.GetChild(i);
    }
}
