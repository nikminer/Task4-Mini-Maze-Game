using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    void Update()
    {
        if (Input.GetAxis("Key1") >= 1)
        {
            cam1.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);
        }

        if (Input.GetAxis("Key2") >= 1)
        {
            cam1.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);
        }
    }
}
