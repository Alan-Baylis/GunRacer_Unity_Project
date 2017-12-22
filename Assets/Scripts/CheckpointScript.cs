using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour {

    //public Transform[] ListCheckpoint;
    //public Transform ActiveCheckpoint;
    //public RespawnCar Car;
    private Transform Checkpoint;
    // Use this for initialization	
    public int Id;

    void Start () {
        Checkpoint = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider c)
    {
        //Car.SetLastCheckpoint(Checkpoint);
        c.GetComponent<RespawnCar>().SetLastCheckpoint(Checkpoint);
        c.GetComponent<VictoryScript>().AllPassed[Id] = true;

        //Debug.Log("Checkpoint x : " + Checkpoint.position.x.ToString());
    }
}
