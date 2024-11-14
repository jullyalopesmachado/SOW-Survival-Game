using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{

    float bulletSpeed = 3000;
    public GameObject bullet;
    public bool Firing = false;

    void Start()
    {

    }

    // If you press the mouse left key (the name referenced in Unity is "Fire1"),
    // it will process the "Fire" fuction listed below.
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Firing == false)
            {
                StartCoroutine(Fire());
            }
        }

    }

   

    IEnumerator Fire()
    {

        Firing = true;
        GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
        Destroy(tempBullet, 1.5f);
        yield return new WaitForSeconds(0.31f);
        Firing = false;
    }
}
