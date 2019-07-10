using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomSpawner : MonoBehaviour
{

    private SpawnerPoint[] atomSpawners;
    // Start is called before the first frame update
    void Start()
    {

        atomSpawners = GetComponentsInChildren<SpawnerPoint>();
    }

    public void Spawn() {

        System.Random random = new System.Random();
        int index = random.Next(atomSpawners.Length);

        atomSpawners[index].Spawn();
    }
}
