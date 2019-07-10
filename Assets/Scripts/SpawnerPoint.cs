using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPoint : MonoBehaviour
{

    public GameObject atomPrefab;

    public static int MAX_FORCE = 100;

    void Start(){
        
    }

    public void Spawn() {

        System.Random random = new System.Random();

        int sign = random.NextDouble() > 0.5f ? -1 : 1;
        float x = sign * random.Next(MAX_FORCE);

        sign = random.NextDouble() > 0.5f ? -1 : 1;
        float y = sign * random.Next(MAX_FORCE);

        sign = random.NextDouble() > 0.5f ? -1 : 1;
        float z = sign * random.Next(MAX_FORCE);

        GameObject newAtom = Instantiate(atomPrefab, transform.position, atomPrefab.transform.rotation);
        Atom atom = newAtom.GetComponent<Atom>();
        atom.Movement = new Vector3(x,y,z);
    }
}
