using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public int BulletDamage;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 4);
	}

    private void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.GetComponent<LifeScript>())
        {
            c.gameObject.GetComponent<LifeScript>().Damage(BulletDamage);
        }
        Destroy(gameObject);
    }
}
