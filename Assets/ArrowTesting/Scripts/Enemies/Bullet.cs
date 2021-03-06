﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public float maxDistance;

    private float damage;
    private GameObject player;
    public Rigidbody bulletR;
    

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        Invoke("DestroyBullet", 8f);
        bulletR = GetComponent<Rigidbody>();
        bulletR.useGravity = false;

	}
	
	// Update is called once per frame
	void Update () {
        // transform.Translate(Vector3.forward * Time.deltaTime * speed);
        // maxDistance += 1 * Time.deltaTime;
        
		
	}
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            Debug.Log("TAKE DAMAGE");
            //lower the players HP
            player.GetComponent<PlayerHealth>().playerHP--;
            DestroyBullet();
            //player.GetComponent<PlayerPrefs>().health -= 20;
        }


        if(other.tag == "Ground")
        {
            Debug.Log("BULLET HIT GROUND");
            DestroyBullet();
        }
    }

    



    public void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
