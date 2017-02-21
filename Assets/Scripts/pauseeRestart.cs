using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseeRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("q"))
        {
            Application.Quit();
        }
        if(Input.GetKey("r"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
	}
}
