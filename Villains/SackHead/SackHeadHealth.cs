using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SackHeadHealth : MonoBehaviour
{

    public GameObject TheSackHead;
    public int TheSackHeadHealthPoint = 100;
    int HurtTheSackHead = 10;
    public GameObject TheSackHeadSound;
    public AudioSource TheSackHeadHurtSound;
    public AudioSource TheSackHeadDeathSound;

    public GameObject TheSackHeadAttackTrigger;
    public GameObject TheSackHeadWeapon;
    public GameObject ThisTrigger;



    void Start()
    {

    }

    void OnTriggerEnter(Collider collision)

    {
        if (collision.transform.tag == "Bullet")
        {

            StartCoroutine(HurtSeq());


        }

    }

    //Stop chase the Player, and play the hurt animation.
    IEnumerator HurtSeq()
    {

        //Disable TheOldLady AI (stop chase the player)
        TheSackHead.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
        TheSackHead.GetComponent<SackHeadChasing>().enabled = false;

        //deduct TheOldLady's health value.
        TheSackHeadHealthPoint -= HurtTheSackHead;

        //Play hurt animation & sound.
        TheSackHeadHurtSound.Play();
        TheSackHead.GetComponent<Animator>().Play("TheSackHeadHurt");
        yield return new WaitForSeconds(1.5f);
        // In TheOldLady's Animation Controller, remember to add a transition from "TheOldLadyHurt" to "TheOldLadyWalk" animation clip,
        // so after the "TheOldLadyHurt" clip finished, it will play the "TheOldLadyWalk" clip.


        //Reset TheOldLady AI (start chase the player)
        TheSackHead.GetComponent<SackHeadChasing>().enabled = true;
        TheSackHead.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;


    }



    void Update()

    {

        if (TheSackHeadHealthPoint <= 0)
        {
            //Disable TheOldLady AI (stop chase the player)
            TheSackHeadAttackTrigger.SetActive(false);
            TheSackHead.GetComponent<SackHeadChasing>().enabled = false;
			TheSackHead.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
            TheSackHeadWeapon.SetActive(false);
            ThisTrigger.SetActive(false);


            //Play death animation & sound.
            TheSackHead.GetComponent<Animator>().Play("TheSackHeadDeath");
            TheSackHeadSound.SetActive(false);
            TheSackHeadDeathSound.Play();



        }

    }




}













