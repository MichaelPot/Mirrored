using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject character;
    public GameObject pistol;

	// Use this for initialization
	void Start () {
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
