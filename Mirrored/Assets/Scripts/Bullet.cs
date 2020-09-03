using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //public Vector3 dir;
    public GameObject b;
    GameObject player;
    GameObject MeleeEnemy;

    float moveSpeed = 8000;//110f;
    Rigidbody rb;
    Vector3 frwd;

	// Use this for initialization
	void Start ()
    {
        frwd = Camera.main.transform.forward;
        player = GameObject.FindGameObjectWithTag("Player");
        //frwd = player.transform.forward;
        rb = GetComponent<Rigidbody>();
        MeleeEnemy = GameObject.FindGameObjectWithTag("MeleeEnemy");
        if (MeleeEnemy != null)
        {
            //Physics.IgnoreLayerCollision(8, 2);
            Physics.IgnoreCollision(MeleeEnemy.GetComponent<Collider>(),GetComponent<Collider>());
            Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        }
       //int k = MeleeEnemy.GetComponent<MeleeEnemyController>().health;  
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rb.velocity = frwd * moveSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, dir, moveSpeed * Time.deltaTime);
        //Destroy(this, 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("MeleeEnemy"))
        {
            //Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);

            MeleeEnemyHealth meleeHealth = collision.collider.GetComponentInParent<MeleeEnemyHealth>();
            
            if (meleeHealth != null)
            {
                meleeHealth.TakeDamage(100);
                
            }
            //collision.gameObject.GetComponent<MeleeEnemyController>().health = 0;
            //Destroy(collision.gameObject, .01f);
            //MeleeEnemy.GetComponent<MeleeEnemyController>().health = 0;
        }

        Destroy(gameObject);
    }

    /*private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("MeleeEnemy"))
        {
            //Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);

            MeleeEnemyHealth meleeHealth = collision.collider.GetComponentInParent<MeleeEnemyHealth>();

            if (meleeHealth != null)
            {
                meleeHealth.TakeDamage(100);

            }
            //collision.gameObject.GetComponent<MeleeEnemyController>().health = 0;
            //Destroy(collision.gameObject, .01f);
            //MeleeEnemy.GetComponent<MeleeEnemyController>().health = 0;
        }

        Destroy(gameObject, .01f);
    }*/
    /*public void EnemyTakeDamage(int amount)
    {

    }
    */
}
