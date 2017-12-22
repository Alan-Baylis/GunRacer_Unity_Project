using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCar : MonoBehaviour {

    public float PvMax;
    public float CurrentPv;
    public Transform UiLife;
    public GameObject ExplosionParticle;

    public string Respawn;

    public void Damage(int i)
    {
        CurrentPv -= i;
    }

    public void ResetPv()
    {
        CurrentPv = PvMax;
    }
    // Use this for initialization
    void Start () {
        ResetPv();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(Respawn))
        {
            CurrentPv = 0;
            //gameObject.GetComponent<VictoryScript>().StatCheckpoint;
        }
            
        if(CurrentPv >= 0)
        {
            float fact = CurrentPv / PvMax;
            UiLife.localScale = new Vector3(fact, 1, 1);
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Bullet")
        {
            Damage(c.GetComponent<DamageScript>().DamagePoint);
            //ContactPoint contact = c.GetComponent<ContactPoint>();
            //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            //Vector3 pos = contact.point;
            //Instantiate(ExplosionParticle, pos, rot);

            Destroy(c.gameObject);
        }
        if (c.gameObject.tag == "Mine")
        {
            Damage(c.GetComponent<DamageScript>().DamagePoint);

            Destroy(c.gameObject, 1.5f);
        }
    }
    //private void OnCollisionEnter(Collision c)
    //{
    //    if (c.gameObject.tag == "Bullet")
    //    {
    //        Damage(c.gameObject.GetComponent<DamageScript>().DamagePoint);
    //        Vector3 Pos = c.contacts[0].point;
    //        Instantiate(ExplosionParticle, Pos, Quaternion.identity);

    //        Destroy(c.gameObject);
    //    }
    //}

}
