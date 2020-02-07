using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /* Another way to do camera rotation
     * 
     *     Vector2 mouseLook, smoothV;
           public float sensitivity = 5.0f, smoothing = 2.0f;

     *         var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
        
     */

    /* from inside playerController
     * transform.position=transform.forward;
               Vector3 dir = new Vector3(hit.point.x, 0.0f, hit.point.z) * moveSpeed;
               rb.velocity = dir;

                if (transform.position == new Vector3(hit.point.x, transform.position.y, hit.point.z))
                {
                    transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                }*/

    /* from inside pistolController -- doesn't work
     * Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0f));
    GameObject b = GameObject.Instantiate(Bullet, gunEnd.position, Quaternion.identity);
    RaycastHit hit;

     if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, 100))
    {
     b.GetComponent<Bullet>().dir = Vector3.MoveTowards(gunEnd.transform.position, rayOrigin, 50f);
     //b.GetComponent<Bullet>().dir = rayOrigin;
    }*/
}
