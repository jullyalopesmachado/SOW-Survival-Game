using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{

    public GameObject Door;
	public AudioSource OpenDoorAudio;
	public AudioSource CloseDoorAudio;


    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
		Door.GetComponent<Animator> ().Play ("DoorOpenAnime");
		OpenDoorAudio.Play ();
        }
    }

    void OnTriggerExit(Collider collision)
    {
		Door.GetComponent<Animator> ().Play ("DoorCloseAnime");
		CloseDoorAudio.Play ();
    }

  }