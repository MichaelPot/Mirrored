using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speedH, speedV;
    public float yaw = 0f, pitch = 0f;
    
    //public float timeBetweenPorts = 1f;

    public GameObject Mirror;
    public int moveSpeed, health = 100;

    Vector3 moveDirection;
    Vector3 pointToGo;
    Vector3 mirrorLoc = new Vector3(-39, 8, -5);
    bool moving = false;
    
    //float timer;

    int mirrorMask;

    Rigidbody rb;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Use this for initialization
    void Start () {
        mirrorMask = LayerMask.GetMask("Mirror");
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        //timer += Time.deltaTime;

        yaw = speedH * Input.GetAxis("Mouse X");
        pitch = speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles += new Vector3(-pitch, yaw, 0f);
        
        if (Input.GetButton("Jump") && !moving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward/*ray*/, 
                out hit, 1000, mirrorMask)) 
            {
                if (hit.collider.gameObject.tag == "Mirror")
                {
                    if (hit.transform.position + hit.transform.forward != mirrorLoc)
                    {
                        moving = true;
                        pointToGo = hit.point;

                        transform.localEulerAngles = new Vector3(0, 0, 0) + hit.transform.localEulerAngles;
                        mirrorLoc = hit.transform.position + hit.transform.forward;
                    }
                }
                //timer = 0f;
            }
        }

        if(moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointToGo, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = mirrorLoc;
        }

        if (Input.GetMouseButtonDown(1))
        {
            makeMirror();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mirror")
        {
            moving = false;
            transform.position = mirrorLoc;//collision.transform.position;
        }
    }

    private void makeMirror()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            GameObject m = GameObject.Instantiate(Mirror, hit.point, hit.transform.rotation);
        }
    }
}
