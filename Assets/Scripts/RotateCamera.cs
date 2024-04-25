using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 90.0f;
    public float maxRotationUp = 45.0f;
    public float maxRotationDown = 315.0f;

    // Update is called once per frame
    void Update()
    {
        bool isUpPressed = Input.GetKey(KeyCode.UpArrow);
        bool isDownPressed = Input.GetKey(KeyCode.DownArrow);

        if (isUpPressed) //la fonction up fonctionne : entre 0 et 45�, on peut �voluer, et en approchant les 45�, la cam�ra se set up automatiquement � 45� pile
                         //si on d�passe 0, et qu'on appuie sur up, la cam�ra se set up automatiquement car elle d�passe les boundaries
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);

            //cette partie fonctionne mais que pour le haut, de 0 et 45�
            /*float currentRotation = transform.eulerAngles.x;
            float clampedRotation = Mathf.Clamp(currentRotation + rotationSpeed * Time.deltaTime, -45, maxRotationUp);
            transform.eulerAngles = new Vector3(clampedRotation, transform.eulerAngles.y, transform.eulerAngles.z);

            if (Mathf.Approximately(clampedRotation, maxRotationUp))
            {
                transform.eulerAngles = new Vector3(maxRotationUp, transform.eulerAngles.y, transform.eulerAngles.z);
            }*/
        }
        if (isDownPressed) //pour le cot� down, probl�mes pour impl�menter les boundaries donc suppression totale (on peut tourner � 360 pour l'instant)
        {
            transform.Rotate(Vector3.right * -rotationSpeed * Time.deltaTime);
        }
    }
}