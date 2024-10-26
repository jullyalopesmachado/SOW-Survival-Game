using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressKeyOpenCabinet : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public AudioSource DrawerOpenSound;
    public bool Action = false;
	public GameObject Dialogue;
    public GameObject PickUpObjectTrigger;

    void Start()
    {
        Instruction.SetActive(false);
		Dialogue.SetActive (false);
		PickUpObjectTrigger.SetActive (false);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Instruction.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        Action = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                Instruction.SetActive(false);
                AnimeObject.GetComponent<Animator>().Play("DrawerOpen");
                ThisTrigger.GetComponent<BoxCollider>().enabled = false;
                DrawerOpenSound.Play();
                Action = false;
				
				//Allow player to pick up objects in the drawer.
				StartCoroutine (PickUpObjects ());	
            }
        }

    }
	
	
	
	IEnumerator PickUpObjects () {
	yield return new WaitForSeconds (1f);
	Dialogue.SetActive (true);

	yield return new WaitForSeconds (4f);
	Dialogue.SetActive (false);

	yield return new WaitForSeconds (0.5f);
	PickUpObjectTrigger.SetActive (true);
	
	}
	
	
	
	
}


