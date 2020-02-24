using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyHealth : MonoBehaviour {

    int health = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount)
    {
        if (health > 0)
        {
            health -= amount;
        }

        if (health <= 0)
        {
            Destroy(gameObject, .1f);
        }
    }
}
