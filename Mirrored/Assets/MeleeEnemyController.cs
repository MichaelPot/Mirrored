using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyController : MonoBehaviour {

    //public GameObject player, playerWeapon;

    GameObject player, playerWeapon;
    //Transform player;
    GameObject playerObj;
    Animator anim;
    //Animation animation;
    NavMeshAgent nav;
    Vector3 playerPos;
    bool playerInRange = false;
    float timer;
    bool active = false;

    void Start () {


        player = GameObject.FindGameObjectWithTag("Player");//.transform;
        playerWeapon = GameObject.FindGameObjectWithTag("PlayerWeapon");
        playerObj = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("run", true);
        anim.SetBool("inRange", false);
        nav.isStopped = true;
        //nav.isStopped = false;
    }
	
	void Update () {
        //nav.isStopped = true;
        timer += Time.deltaTime;
        nav.SetDestination(new Vector3(player.transform.position.x/*.transform.position.x*/, 0, player.transform.position.z/*.transform.position.z*/));
        anim.SetBool("run", true);
        //  Debug.Log(health);
        if (active)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }
        //  Debug.Log(health);

        if (playerWeapon.GetComponent<PistolController>().GetHasShot())
        {
            nav.isStopped = false;
            active = true;
        }

        if (playerInRange)
        {
            nav.isStopped = true;
            if (timer >= .8)//anim.GetCurrentAnimatorStateInfo(0).normalizedTime == 1)
            {
                player.GetComponent<PlayerController>().health -= 100;
                Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                timer = 0;
            }
            else
            {
                //Debug.Log("PLAYING POOP");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
            //nav.isStopped = true;
            anim.SetBool("inRange", true);
            timer = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
            nav.isStopped = false;
            anim.SetBool("inRange", false);
        }
    }

    private void OnDestroy()
    {
        GetComponentInParent<EnemySpawner>().SetCount();
    }
}
