using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SackHeadIdle : MonoBehaviour
{

    public GameObject SackHead;
    public Transform Player;


    void Update()
    {
        SackHead.GetComponent<Animator>().Play("TheSackHeadIdle");
        transform.LookAt(Player);

    }
}



