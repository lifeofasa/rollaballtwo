using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupScript : MonoBehaviour {

    public GameObject prefabPickups;
	// Use this for initialization
	void Start () {
        for (int i = 1; i < 10; i++)
        {
            for (int j = 1; j < 10; j++)
            {
                if ((i + j) % 2 == 0 && isCenter(i, j) == false)
                {
                    if (Random.Range(0, 100) % 10 == 0)
                    {
                        GameObject go = Instantiate(prefabPickups, new Vector3(-4.5f + i, 0, -4.5f + j), Quaternion.identity) as GameObject;
                        go.transform.parent = GameObject.Find("WholePlatform").transform;
                    }
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

    // Update is called once per frame
    void Update () {
		
	}
}
