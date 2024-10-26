using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemPeleIdle : MonoBehaviour
{

    public GameObject SemPele;
    public Transform Player;


    void Update()
    {
        SemPele.GetComponent<Animator>().Play("TheSemPeleIdle");
        transform.LookAt(Player);

    }
}



