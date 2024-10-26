using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SackHeadChasing : MonoBehaviour
{

    public GameObject SackHead;
    public NavMeshAgent TheSackHeadNav;
    public Transform Player;


    void Start()
    {
		SackHead.GetComponent<Animator>().Play("TheSackHeadWalk");
    }


    void Update()
    {


        TheSackHeadNav.SetDestination(Player.position);
		

    }

}