using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsGunCtrl : MonoBehaviour {

    public GameObject LightsOff;
	public GameObject FlashlightMode1;
    public GameObject FlashlightMode2;
    public GameObject Lantern;
    public GameObject Gun;
	public int LightSeq;
	public int GunSeq;

    void Start () {

        FlashlightMode1.SetActive(false);
        FlashlightMode2.SetActive(false);
        Lantern.SetActive(false);
		LightsOff.SetActive(true);
        Gun.SetActive(false);
    }
	

	void Update () {
		if (Input.GetKeyDown ("c")){
			if (LightSeq == 3)
				{ LightSeq = 0; }		
			else 
				{ LightSeq += 1; }
			StartCoroutine (LightSwitch());	
		}
		
		if (Input.GetKeyDown ("r")){
			if (GunSeq == 1)
				{ GunSeq = 0; }		
			else 
				{ GunSeq += 1; }
			StartCoroutine (GunSwitch());	
		}
		
		
	}
	
	IEnumerator LightSwitch () {
		yield return new WaitForSeconds (0.001f);
		
		if(LightSeq == 0)
			{	FlashlightMode1.SetActive(true);
        		FlashlightMode2.SetActive(false);
        		Lantern.SetActive(false);
			 	LightsOff.SetActive(false);
			}
		
		if(LightSeq == 1)
			{	FlashlightMode1.SetActive(false);
        		FlashlightMode2.SetActive(true);
        		Lantern.SetActive(false);
			 	LightsOff.SetActive(false);
			}
		
		
		if(LightSeq == 2)
			{	FlashlightMode1.SetActive(false);
        		FlashlightMode2.SetActive(false);
        		Lantern.SetActive(true);
			 	LightsOff.SetActive(false);
			}
		
		if(LightSeq == 3)
			{	FlashlightMode1.SetActive(false);
        		FlashlightMode2.SetActive(false);
        		Lantern.SetActive(false);
			 	LightsOff.SetActive(true);
			}
			
			
		
	}
	
	
	IEnumerator GunSwitch () {
		yield return new WaitForSeconds (0.001f);
		
		if(GunSeq == 0)
			{	
				Gun.SetActive(true);
			}
		
		if(GunSeq == 1)
			{	
				Gun.SetActive(false);
			}
		
		
	}	
	
	
}
	
