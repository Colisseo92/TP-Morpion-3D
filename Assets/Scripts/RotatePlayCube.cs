using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayCube : MonoBehaviour
{
    public float rotationSpeed = 90;
    Vector3 rotationAxis = new Vector3(0, 1, 0);

    // Update is called once per frame
    void Update()
    {
        bool isLeftPressed = Input.GetKey(KeyCode.LeftArrow);
        bool isRightPressed = Input.GetKey(KeyCode.RightArrow);

        if (isLeftPressed)
        {
            transform.Rotate(rotationAxis * -rotationSpeed * Time.deltaTime);
        }
        else if (isRightPressed)
        {
            transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
        }
    }
}