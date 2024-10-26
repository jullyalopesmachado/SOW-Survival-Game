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

    //In the game, we will create a Bullet Generator in front of the gun and apply this script to it.
    //Then, we will create a bullet model, make it to a prefab object, and assign it as the "bullet" game object referenced in this script. 

    //When firing, it will generate this bullet prefab, and make it to move in the Z axis (the front direction of the Bullet Generator).
    //The move speed is 3000 (declared in the begining of this script, and you can change the number to change the script).
    //After 1.5 seconds (the "1.5f" below is the time), it will destroy this bullet.
    //(You can extend the time if you would like it to fly further.)

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
