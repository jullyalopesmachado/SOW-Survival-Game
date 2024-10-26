using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SackHeadAwake : MonoBehaviour
{

    public GameObject TheSackHead;
    public AudioSource TheSackHeadSound;
    public GameObject TheSackHeadAttackTrigger;

    public GameObject ThisTrigger;


    void Start()
    {
        TheSackHead.GetComponent<SackHeadChasing>().enabled = false;
        TheSackHeadAttackTrigger.SetActive(false);
    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "Bullet")
        {
            TheSackHead.GetComponent<SackHeadChasing>().enabled = true;
            TheSackHeadSound.Play();
            TheSackHeadAttackTrigger.SetActive(true);


            TheSackHead.GetComponent<SackHeadIdle>().enabled = false;
            ThisTrigger.SetActive(false);
        }

    }


}