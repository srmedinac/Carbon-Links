using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronSpawner : MonoBehaviour
{
    private WeakForce[] electrons;
    private Transform[] spawnPoints;

    void Start(){
    
        electrons = GetComponentsInChildren<WeakForce>();
        spawnPoints = new Transform[electrons.Length];
        for (int i = 0; i < electrons.Length; i++) spawnPoints[i] = electrons[i].transform;
    }

    public void SpawnElectron() {

        System.Random random = new System.Random();
        int i = random.Next(0, electrons.Length);

        electrons[i].transform.position = spawnPoints[i].position;
    }
}
