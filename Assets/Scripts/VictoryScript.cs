using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour {

    //public CheckpointScript[] ListCheckpoint;
    //public Dictionary<CheckpointScript,bool> ListIsPassedCheckpoint;
    public int TotCheckpoint = 6;
    public int StatCheckpoint = 0;
    //public bool AllPassed;
    public Text WinText;
    public List<bool> AllPassed = new List<bool>();
	// Use this for initialization
	void Start () {
        for (int i = 0; i < TotCheckpoint; i++)
        {
            AllPassed.Add(false);
        }


        WinText.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {


        //if(!AllPassed.Contains(false))
        //if (StatCheckpoint == TotCheckpoint)
        if (!AllPassed.Contains(false))
        {
            WinText.text = gameObject.name + " a gagné la course !";
            WinText.gameObject.SetActive(true);
            StartCoroutine(ReloadScene());
        }
            

	}


    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(5);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void SetCheckpointPassed()
    {
        //ListIsPassedCheckpoint[Checkpoint] = true;
        StatCheckpoint += 1;
    }
}
