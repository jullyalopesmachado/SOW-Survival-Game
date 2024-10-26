using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;


public class PressKeyPickUpObject : MonoBehaviour
{
    public GameObject ThePlayer;
	public GameObject Instruction;
    public GameObject ThisTrigger;
    public GameObject ObjectOnGround;
    public GameObject ObjectOnHand;
    public GameObject NextInstruction;
    public AudioSource PickUpObjectSound;
    public bool Action = false;

    void Start()
    {
        Instruction.SetActive(false);
        ObjectOnGround.SetActive(true);
        ObjectOnHand.SetActive(false);
        NextInstruction.SetActive(false);

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
                ObjectOnGround.SetActive(false);
                ObjectOnHand.SetActive(true);
                ThisTrigger.GetComponent<BoxCollider>().enabled = false;
                PickUpObjectSound.Play();
                Action = false;
				
				//Allow player to see the Next Instruction for few seconds.
				StartCoroutine (ShowNextInstruction ());	

            }
        }

    }
	
	IEnumerator ShowNextInstruction () {
	yield return new WaitForSeconds (0.1f);
    NextInstruction.SetActive(true);
	ThePlayer.GetComponent<FirstPersonController>().enabled = false;

	yield return new WaitForSeconds (4f);
    NextInstruction.SetActive(false);

	yield return new WaitForSeconds (0.5f);
	ThePlayer.GetComponent<FirstPersonController>().enabled = true;
	ThisTrigger.SetActive(false);
	
	}
	
	
	
	
}


