using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

    public Transform BulletStartPosition;
    public GameObject PrefabBullet;
    public int SpeedBullet;
    public int MaxBullet;
    public int CurrentBullet;
    

	// Use this for initialization
	void Start () {
        CurrentBullet = MaxBullet;
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    public void Shoot()
    {
        BulletStartPosition.transform.rotation = new Quaternion(0, 0, 0, 0);
        CurrentBullet -= 1;
        GameObject Bullet = Instantiate<GameObject>(PrefabBullet);
        Bullet.transform.position = BulletStartPosition.position;
        Bullet.transform.localRotation = BulletStartPosition.transform.rotation;
        Bullet.GetComponent<Rigidbody>().AddForce(BulletStartPosition.forward * SpeedBullet);

        // Destroy the bullet after 2 seconds
        DestroyObject(Bullet, 3.0f);
      
        if (CurrentBullet<=0)
        {
            Destroy(gameObject);
        }

        if (GetComponent<AudioSource>())
            GetComponent<AudioSource>().Play();
    }
}
