using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCell : MonoBehaviour
{
    public GameObject Victory;
    private void Start()
    {
        Victory = GameObject.FindWithTag("VictoryScreen");
        Victory.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Victory.SetActive(true);
    }
}
