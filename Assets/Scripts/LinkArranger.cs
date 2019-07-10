using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LinkArranger : MonoBehaviour
{
    public Transform[] Links { get { return links; } }
    public Transform[] LinkPositions { get { return linkPositions; } }
    public bool HasEmptyLinks { get {

            foreach (var link in links) if (link == null) return true;
            return false;
        } 
    }

    private System.Random random;
    private Transform[] links;
    private Transform[] linkPositions;

    private int numberOfLinks;

    void Start()
    {
        random = new System.Random();
        numberOfLinks = GameManager.linkType == LinkType.TETRAHEDRON ? 4 : 3;
        links = new Transform[numberOfLinks];
        linkPositions = new Transform[numberOfLinks];

        Debug.Log($"Link type is {GameManager.linkType}");

        for (int i = 0; i < numberOfLinks; i++) linkPositions[i] = transform.GetChild(i);
    }

    public void Link(Transform atom) {
    
        int i = GetEmptyLinkIndex();
        if (i == -1) return;
        atom.transform.position = linkPositions[i].position;
        links[i] = atom;
    }

    public void SetLinkAtIndex(int index, Transform atom) {
        links[index] = atom;
    }

    public Transform GetEmptyLink() {
    
        for(int i=0; i<links.Length; i++) if (links[i] == null) return linkPositions[i];   
        return null;
    }

    public int GetEmptyLinkIndex() {
    
        for (int i = 0; i < links.Length; i++) if (links[i] == null) return i; 
        return -1;
    }
}
