using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCar : MonoBehaviour {

    public Transform CarTransform;
    public Transform LastCheckpoint;

	// Use this for initialization
	void Start () {
        CarTransform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckLife();
    }

    public void SetLastCheckpoint (Transform Checkpoint)
    {
        LastCheckpoint = Checkpoint;
    }

    public void Respawn()
    {
        CarTransform.position = LastCheckpoint.position;
        gameObject.GetComponent<LifeCar>().ResetPv();
    }

    public void CheckLife()
    {
        if (gameObject.GetComponent<LifeCar>().CurrentPv <= 0)
            Respawn();
    }
}
