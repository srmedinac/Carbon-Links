using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static LinkType linkType = LinkType.PLAIN;

    void Start() {
        DontDestroyOnLoad(this);
    }

    public void LoadScene(string scene) {

        SceneManager.LoadScene(scene);
    }

    public void SetLinkType(Dropdown dropDown) {

        linkType = dropDown.value == 0 ? LinkType.PLAIN : LinkType.TETRAHEDRON;
    }
}

public enum LinkType { 

    TETRAHEDRON,
    PLAIN
}
