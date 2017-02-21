using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateWalls : MonoBehaviour {

    public Transform hinge; 

    public GameObject prefabWalls;

    private int random;

    private Quaternion currentRotation;

    // Use this for initialization
    void Start () {
	    for (int i = 1; i < 10; i++)
        {
            for (int j = 1; j < 10; j++)
            {
                if ((i + j) % 2 == 0 && isCenter(i, j) == false) {

                    GameObject go = Instantiate(prefabWalls, new Vector3(-5 + i, 0, -5 + j), Quaternion.identity) as GameObject;
                    go.transform.parent = GameObject.Find("WholePlatform").transform;

                    random = Random.Range(0, 4);

                    go.transform.Rotate(0, 90f * random, 0);
                }
            }
        }
	}

    private bool isCenter(int i, int j)
    {
        if (i == 5 && j == 5)
        {
            return true;
        }
        return false;
    }
	
}
