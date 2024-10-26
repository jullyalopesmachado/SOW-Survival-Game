using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingHuman : MonoBehaviour
{

    public GameObject HangingGuy;
    public Transform Player;


    void Update()
    {
        HangingGuy.GetComponent<Animator>().Play("TheHangingHuman");
        transform.LookAt(Player);

    }
}



