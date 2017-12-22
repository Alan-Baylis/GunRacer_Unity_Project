using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHandler : MonoBehaviour {

    public GameObject CurentWeapon;
    public KeyCode shoot;
    public Text Ammo;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		 if (CurentWeapon != null)
            {
            if (Input.GetKeyDown(shoot))
            {
                gameObject.GetComponentInChildren<ShootScript>().Shoot();
            }

            Ammo.text = CurentWeapon.GetComponent<ShootScript>().CurrentBullet.ToString() + "/" + CurentWeapon.GetComponent<ShootScript>().MaxBullet.ToString();
        }

        
    }

    //IEnumerator CallShoot()
    //{
    //    yield return WaitForEndOfFrame;
    //    gameObject.GetComponentInChildren<ShootScript>().Shoot();
    //}
}
