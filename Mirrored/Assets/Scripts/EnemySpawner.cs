using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject MeleeEnemy;

    int count = 0;
    bool firstWave = false, secondWave = false;
    public bool allDead = false;
	// Use this for initialization
	void Start () 
    {

        count = 0;
        /* spawns enemies at start of level */
        GameObject.Instantiate(MeleeEnemy, new Vector3(-6.3f, 0, 32.7f), Quaternion.Euler(0, 180, 0), gameObject.transform);
        GameObject.Instantiate(MeleeEnemy, new Vector3(0, 0, -56.5f), Quaternion.Euler(0, 0, 0), gameObject.transform);
        GameObject.Instantiate(MeleeEnemy, new Vector3(-36, 0, 32), Quaternion.Euler(0, 125, 0), gameObject.transform);
        GameObject.Instantiate(MeleeEnemy, new Vector3(-36, 0, -34), Quaternion.Euler(0, 45, 0), gameObject.transform);
        GameObject.Instantiate(MeleeEnemy, new Vector3(36.8f, 0, -1f), Quaternion.Euler(0, -90, 0), gameObject.transform);
        GameObject.Instantiate(MeleeEnemy, new Vector3(27.4f, 0, -24f), Quaternion.Euler(0, -20, 0), gameObject.transform);
        Debug.Log(count);
    }
	
	// Update is called once per frame
	void Update () 
    {
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

        if (count == 11)
        {
            allDead = true;
        }
    }

    /* used to keep track of how many enemies have been killed to spawn the next wave */
    public void SetCount()
    {
        count++;
        Debug.Log(count);
    }
}
