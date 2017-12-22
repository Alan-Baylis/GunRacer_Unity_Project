using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Player")
        {
            this.gameObject.transform.parent = c.transform;
            if (this.gameObject.tag == "RocketLauncher")
            {
                this.gameObject.transform.localPosition = new Vector3(-0.12f, 1f, -0.04f);
                this.gameObject.transform.localRotation = new Quaternion(0.165f, -179.819f, 0.086f,0);
                this.gameObject.GetComponent<SphereCollider>().enabled = false;
            }
            if (this.gameObject.tag == "Gun")
            {
                this.gameObject.transform.localPosition = new Vector3(-0.12f, 1.192f, -0.04f);
                this.gameObject.transform.localRotation = new Quaternion(0.165f, -179.819f, 0.086f, 0);
                this.gameObject.GetComponent<SphereCollider>().enabled = false;
            }

            if (c.GetComponent<WeaponHandler>().CurentWeapon != null)
                Destroy(c.GetComponent<WeaponHandler>().CurentWeapon);

            c.GetComponent<WeaponHandler>().CurentWeapon = gameObject;
        }
        
    }
}
