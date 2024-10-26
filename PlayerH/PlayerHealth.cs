using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class PlayerHealth : MonoBehaviour
{

    public GameObject ThePlayer;
    public int Health = 100;
    int Damage = 10;
    public GameObject HealthDisplay;

    public int PlayHurtSound;
    public AudioSource HurtSound1;
    public AudioSource HurtSound2;
    public AudioSource HurtSound3;
    public AudioSource HurtSound4;


    public GameObject YouLoseScreen;
    public bool InAttackRange = false;

    void Start()
    {
		YouLoseScreen.SetActive(false);
        print("Your health value is: " + Health);

    }

    void OnTriggerEnter(Collider collision)

    {
        if (collision.transform.tag == "Enemy")
        {
            InAttackRange = true;
            StartCoroutine(HurtPlayer());

        }

    }


    void OnTriggerExit(Collider collision)
    {
        InAttackRange = false;

    }



    IEnumerator HurtPlayer()
    {
        while (true && InAttackRange == true)
        {
            Health -= Damage;
            print("Enemy just hurted you! " + "Your health value is: " + Health);
            HealthDisplay.GetComponent<Text>().text = "" + Health;

            PlayHurtSound = Random.Range(1, 5);
            if (PlayHurtSound == 1)
            {
                HurtSound1.Play();
            }

            if (PlayHurtSound == 2)
            {
                HurtSound2.Play();
            }

            if (PlayHurtSound == 3)
            {
                HurtSound3.Play();
            }

            if (PlayHurtSound == 4)
            {
                HurtSound4.Play();
            }
            yield return new WaitForSeconds(3f);
        }

    }


    void Update()

    {

        if (Health <= 0)
        {
            HealthDisplay.GetComponent<Text>().text = "" + "0";
            Time.timeScale = 0;
            YouLoseScreen.SetActive(true);
            ThePlayer.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }




}