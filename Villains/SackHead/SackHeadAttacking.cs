using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SackHeadAttacking : MonoBehaviour
{



    public GameObject TheSackHead;
    public bool Attacking;
    public bool InAttackRange = false;


    void Start()
    {

        TheSackHead.GetComponent<Animator>().Play("TheSackHeadWalk");
    }


    void Update()
    {
        if (InAttackRange == true && Attacking == false)
        {
            //Play attack animation.
            StartCoroutine(AttackPlayer());
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            InAttackRange = true;

        }
    }


    void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            InAttackRange = false;
            //Play walk animation.
            TheSackHead.GetComponent<Animator>().Play("TheSackHeadWalk");
        }
    }



    IEnumerator AttackPlayer()
    {

			Attacking = true;
			TheSackHead.GetComponent<Animator>().Play("TheSackHeadAttack");
            yield return new WaitForSeconds(1f);
			Attacking = false;



    }









}