using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speedH, speedV;
    public float yaw = 0f, pitch = 0f;
    
    //public float timeBetweenPorts = 1f;

    public GameObject Mirror, CurrMirror;
    public int moveSpeed, health = 100;

    Vector3 moveDirection;
    Vector3 pointToGo;
    Vector3 rotation;
    Vector3 mirrorLoc = new Vector3(-39, 8, -5);
    bool moving = false, isMirror = false;
    float fixedDeltaTime;
    MeleeEnemyController mEnemy = null;

    //float timer;

    int mirrorMask, enemyMask, mirrorCt = 0;

    Rigidbody rb;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        fixedDeltaTime = Time.fixedDeltaTime;
    }
    // Use this for initialization
    void Start () {
        mirrorMask = LayerMask.GetMask("Mirror");
        enemyMask = LayerMask.GetMask("Enemy");
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        //timer += Time.deltaTime;

        yaw = speedH * Input.GetAxis("Mouse X");
        pitch = speedV * Input.GetAxis("Mouse Y");

        rotation += new Vector3(-pitch, yaw, 0f);
        
        rotation.x = Mathf.Clamp(rotation.x, -90, 90);

        transform.eulerAngles = rotation;
        //transform.eulerAngles += new Vector3(-pitch, yaw, 0f);

        if (health > 0 && Input.GetButton("Jump") && !moving)
        {
            //Debug.Log("OH MY GOD");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (mEnemy != null)
            {
                mEnemy.SetActive();
            }
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward/*ray*/, 
                out hit, 1000, mirrorMask)) 
            {
                if (hit.collider.CompareTag("Mirror"))//hit.collider.gameObject.tag == ("Mirror"))
                {
                    if (hit.transform.position + hit.transform.forward != mirrorLoc)
                    {
                        moving = true;
                        pointToGo = hit.point;

                        rotation = hit.transform.localEulerAngles;
                        mirrorLoc = hit.transform.position + hit.transform.forward;
                        isMirror = true;
                    }
                }
                //timer = 0f;
            }
            else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward/*ray*/,
                out hit, 1000, enemyMask))
            {
                //Debug.Log("FUUUUUCK MEEEE");
                if (hit.collider.CompareTag("MeleeEnemy"))//hit.collider.gameObject.tag == ("Mirror"))
                {
                    mEnemy = hit.collider.gameObject.GetComponentInParent<MeleeEnemyController>();
                    mEnemy.SetInactive();
                    if (hit.transform.position + hit.transform.forward * 2  != mirrorLoc)
                    {
                        moving = true;
                        pointToGo = hit.point + hit.transform.forward * 2;

                        //rotation = hit.transform.localEulerAngles;
                        //transform.localEulerAngles = new Vector3(0, 0, 0) + hit.transform.localEulerAngles;
                        mirrorLoc = hit.transform.position + hit.transform.forward * 2;
                        isMirror = false;
                    }
                }
                //timer = 0f;
            }
        }

        if(moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointToGo, moveSpeed * fixedDeltaTime);
            Time.timeScale = 0.2f;
        }
        else
        {
            transform.position = mirrorLoc;
        }

        if (health > 0 && Input.GetMouseButtonDown(1))
        {
            MakeMirror();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.CompareTag("Mirror")  && isMirror == true) || (collision.collider.CompareTag("MeleeEnemy") && isMirror == false))//collision.gameObject.tag == "Mirror")
        {
            transform.eulerAngles = collision.collider.transform.eulerAngles;
            moving = false;
            transform.position = mirrorLoc;//collision.transform.position;
            CurrMirror = collision.gameObject;
            Time.timeScale = 1f;
        }
    }

    private void MakeMirror()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit) && mirrorCt == 0)
        {
            GameObject m = GameObject.Instantiate(Mirror, new Vector3(hit.point.x, 8.55f, hit.point.z), hit.transform.rotation);
            mirrorCt++;
        }
    }

    public bool IsMoving()
    {
        return moving;
    }
}
