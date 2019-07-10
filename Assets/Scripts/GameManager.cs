using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static LinkType linkType = LinkType.TETRAHEDRON;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum LinkType { 

    TETRAHEDRON,
    PLAIN
}
