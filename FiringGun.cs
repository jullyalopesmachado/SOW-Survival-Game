using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringGun : MonoBehaviour
{

    public GameObject theGun;
    public GameObject MuzzleFlash01;
    public GameObject MuzzleFlash02;
    public GameObject MuzzleFlash03;
    public AudioSource GunShotSound;
    public bool Firing = false;


    // If you press the mouse left key (the name referenced in Unity is "Fire1"),
    // it will process the fuction listed below.
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Firing == false)
            {
                StartCoroutine(GunMechanics());
            }

        }
    }

    IEnumerator GunMechanics()
    {
        // It will play the gun firing animation, and play the gun shot sound clip.
        Firing = true;
        theGun.GetComponent<Animator>().Play("GunShotAnime");
        GunShotSound.Play();

        //This part is to play the Muzzle Flash Animation (the 3 images I provided)
        //Every 2 millisecond, it will enable one image. Therefore, play the three images in a sequence.
        //Since it's fast, it will looked like a Muzzle Flash animation.
        MuzzleFlash01.SetActive(true);
        MuzzleFlash02.SetActive(false);
        MuzzleFlash03.SetActive(false);
        yield return new WaitForSeconds(0.02f);
        MuzzleFlash01.SetActive(false);
        MuzzleFlash02.SetActive(true);
        MuzzleFlash03.SetActive(false);
        yield return new WaitForSeconds(0.02f);
        MuzzleFlash01.SetActive(false);
        MuzzleFlash02.SetActive(false);
        MuzzleFlash03.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        MuzzleFlash01.SetActive(false);
        MuzzleFlash02.SetActive(false);
        MuzzleFlash03.SetActive(false);

        //This part is to reset the animation to the default state (gun will be still).

        yield return new WaitForSeconds(0.25f);
        theGun.GetComponent<Animator>().Play("New State");
        Firing = false;
    }
}
