using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PistolController : MonoBehaviour {

    public float speedH, speedV, moveSpeed;
    public float yaw = 0f, pitch = 0f;
    public float fireRate;
    public GameObject Bullet;

    public int maxAmmo;
    public int ammo;
    public TextMeshProUGUI ammoDisplay;

    public Transform gunEnd;

    Camera fpsCam;
    float timer;
    Vector3 pointToGo;
    bool hasShot = false;

    void Start ()
    {
        fpsCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        ammoDisplay.text = "Ammo: " + ammo.ToString() + "/" + maxAmmo.ToString();

        if (Input.GetMouseButtonDown(0) && timer >= fireRate && ammo > 0 && !GetComponentInParent<PlayerController>().IsMoving())
        {
            ammo--;
            Shoot();
        }
    }
    private void Shoot()
    {
        hasShot = true;
        timer = 0f;

        GameObject b = GameObject.Instantiate(Bullet, gunEnd.position/*transform.position + transform.forward + Vector3.up*/, Quaternion.identity);
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit) && b != null)
        {
            b.GetComponent<Bullet>().dir = hit.point;
        }
    }

    public bool GetHasShot()
    {
        return hasShot;
    }
}
