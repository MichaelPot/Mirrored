using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject MeleeEnemy;

    int count = 0;
    bool firstWave = false, secondWave = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (firstWave == false && count >= 3)
        {
            firstWave = true;

            GameObject.Instantiate(MeleeEnemy, new Vector3(47, 0, 35), Quaternion.Euler(0, 180, 0), gameObject.transform);
            GameObject.Instantiate(MeleeEnemy, new Vector3(47, 0, 0), Quaternion.Euler(0, 180, 0), gameObject.transform);
            GameObject.Instantiate(MeleeEnemy, new Vector3(0, 0, 47.5f), Quaternion.Euler(0, 180, 0), gameObject.transform);
        }

        if (secondWave == false && count >= 6)
        {
            secondWave = true;

            GameObject.Instantiate(MeleeEnemy, new Vector3(47, 0, 47), Quaternion.Euler(0, 180, 0), gameObject.transform);
            GameObject.Instantiate(MeleeEnemy, new Vector3(52, 0, -45), Quaternion.Euler(0, 180, 0), gameObject.transform);
        }
    }

    public void SetCount()
    {
        count++;
    }
}
