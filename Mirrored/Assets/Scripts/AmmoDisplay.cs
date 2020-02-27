using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AmmoDisplay : MonoBehaviour
{
    public int maxAmmo;
    public TextMeshProUGUI ammoDisplay;

    public int ammo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = ammo.ToString() + "/" + maxAmmo.ToString(); 

        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            ammo--;
        }
    }
}
