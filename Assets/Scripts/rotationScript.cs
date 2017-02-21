using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationScript : MonoBehaviour {

    public bool permission;
    public float period = 0.0f;
    public float rotationDegreesPerSecond = 90f;
    public float rotationDegreesAmount = 90f;
    private float totalRotation = 0;
    int sign;
    // Use this for initialization
    void Start()
    {
        permission = false;
        sign = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if we haven't reached the desired rotation, swing
        if (Random.Range(0,700) == 0)
        {
            permission = true;
        }
        if (permission)
        {
            if (period > 3)
            {
                if (sign == 0)
                {
                    int[] array = new int[2] { -1, 1 };
                    sign = array[Random.Range(0,2)];
                }
                if (Mathf.Abs(totalRotation) < Mathf.Abs(rotationDegreesAmount)
                    && (Mathf.Abs(rotationDegreesAmount) - Mathf.Abs(totalRotation)) > Time.deltaTime * Mathf.Abs(rotationDegreesPerSecond))
                {
                    rotate();
                }
                else if (Mathf.Abs(totalRotation) < Mathf.Abs(rotationDegreesAmount))
                {
                    float currentAngle = transform.rotation.eulerAngles.y;
                    transform.rotation = Quaternion.AngleAxis(
                        currentAngle + (sign * (Mathf.Abs(rotationDegreesAmount) - Mathf.Abs(totalRotation))), Vector3.up);
                    totalRotation += (sign * (Mathf.Abs(rotationDegreesAmount) - Mathf.Abs(totalRotation)));
                }
                else if (Mathf.Abs(totalRotation) >= Mathf.Abs(rotationDegreesAmount))
                {
                    totalRotation = 0;
                    period = 0;
                    permission = false;
                    sign = 0;
                }
            }
            period += UnityEngine.Time.deltaTime;
        }
    }

    void rotate()
    {
        float currentAngle = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * sign * rotationDegreesPerSecond), Vector3.up);
        totalRotation += Time.deltaTime * sign * rotationDegreesPerSecond;
    }
}
