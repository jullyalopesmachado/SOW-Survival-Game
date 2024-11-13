using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class ShutOffCellingLights : MonoBehaviour
{
    public GameObject ThePlayer;
	public GameObject ThisTrigger;
	public GameObject DialogueShutOffLights;
    public GameObject LightG1;
	public GameObject LightG2;
	public GameObject LightG3;
	public GameObject LightG4;
	public GameObject LightG5;
    public AudioSource HorrorMusic1;
	public AudioSource ZombieBreathingSound1;
	public AudioSource ShutLightG1Sound;
	public AudioSource ShutLightG2Sound;
	public AudioSource ShutLightG3Sound;
	public AudioSource ShutLightG4Sound;
	public AudioSource ShutLightG5Sound;



    void Start()
    {
        DialogueShutOffLights.SetActive(false);
		
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
			ThisTrigger.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine (ShurtOffLightsSequence ());	
        }
    }

	
	
	IEnumerator ShurtOffLightsSequence () {
	yield return new WaitForSeconds (0.1f);
	ThePlayer.GetComponent<FirstPersonController>().enabled = false;
	DialogueShutOffLights.SetActive(true);
	HorrorMusic1.Play();
	
	yield return new WaitForSeconds (1f);
	LightG1.SetActive (false);
	ShutLightG1Sound.Play();

	yield return new WaitForSeconds (1f);
	LightG2.SetActive (false);
	ShutLightG2Sound.Play();
	DialogueShutOffLights.SetActive(false);
	ZombieBreathingSound1.Play();
		
	yield return new WaitForSeconds (0.5f);
	LightG3.SetActive (false);
	ShutLightG3Sound.Play();
	
	yield return new WaitForSeconds (2f);
	LightG4.SetActive (false);
	ShutLightG4Sound.Play();
	
	yield return new WaitForSeconds (0.7f);
	LightG5.SetActive (false);
	ShutLightG5Sound.Play();
	ThePlayer.GetComponent<FirstPersonController>().enabled = true;
	ThisTrigger.SetActive(false);

	
	}
	
	
	
	
}


