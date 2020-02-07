using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Vector3 dir;
    public GameObject b;
    GameObject MeleeEnemy;

    float moveSpeed = 2;

	// Use this for initialization
	void Start ()
    {
        MeleeEnemy = GameObject.FindGameObjectWithTag("MeleeEnemy");
        if (MeleeEnemy != null)
        {
            Physics.IgnoreLayerCollision(11, 2);
        }
       //int k = MeleeEnemy.GetComponent<MeleeEnemyController>().health;  
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, dir, moveSpeed);//* Time.deltaTime);
        //Destroy(this, 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);

        if (collision.gameObject.tag == "MeleeEnemy" /*&& collision.gameObject.layer != 10*/)
        {
            //Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);

            MeleeEnemyHealth meleeHealth = collision.collider.GetComponentInParent<MeleeEnemyHealth>();
            if (meleeHealth != null)
            {
                meleeHealth.TakeDamage(100);
            }
            //collision.gameObject.GetComponent<MeleeEnemyController>().health = 0;
            //Destroy(MeleeEnemy);
            //MeleeEnemy.GetComponent<MeleeEnemyController>().health = 0;
        }

        Destroy(gameObject);
    }

    public void EnemyTakeDamage(int amount)
    {

    }

}
