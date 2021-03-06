﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshoot : MonoBehaviour {
   
    public float waitTime;
    private float currentTime;
    private bool shot;

    
    public GameObject bullet;
    public GameObject player;
    public GameObject bulletSpawnpoint;
    
   // public GameObject gun;
   // public Transform bulletSpawned;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        //bulletSpawnpoint = GameObject.Find("PistolHolder");
        
		
	}
	
	// Update is called once per frame
	void Update () {

        /*if(health <=0)
        {
            Die();
        }
        */

        this.transform.LookAt(player.transform.position);
        

        
        RaycastHit hit;
        //if enemy has line of sight on player
        if (Physics.Raycast(transform.position, transform.forward * 1000f, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                if (currentTime == 0)
                    Shoot();
                if (shot && currentTime < waitTime)
                    currentTime += 1 * Time.deltaTime;
                if (currentTime >= waitTime)
                    currentTime = 0;

            }
        }
    }
    public void Shoot()
        {
            shot = true;
        GameObject clone = Instantiate(bullet, bulletSpawnpoint.transform.position, bulletSpawnpoint.transform.rotation);
        Rigidbody bulletR = clone.GetComponent<Rigidbody>();
        bulletR.AddForce(clone.transform.forward * 10f, ForceMode.Impulse);
        
        }

   /* public void Die()
    {
        Destroy(this.gameObject);
        // player.GetComponent<PlayerPrefs>().points += pointsToGive; 
    }
	*/
}
