using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshoot : MonoBehaviour {
    public float pointsToGive;
    public float waitTime;
    private float currentTime;
    private bool shot;

    public float health;
    public GameObject bullet;
    public GameObject player;
    public GameObject bulletSpawnpoint;
   // public Transform bulletSpawned;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        //bulletSpawnpoint = GameObject.Find("PistolHolder");
		
	}
	
	// Update is called once per frame
	void Update () {

        if(health <=0)
        {
            Die();
        }
        this.transform.LookAt(player.transform);

        if (currentTime == 0)
            Shoot();
        if (shot && currentTime < waitTime)
            currentTime += 1 * Time.deltaTime;
        if (currentTime >= waitTime)
            currentTime = 0;
    }
    public void Shoot()
        {
            shot = true;
        GameObject clone = Instantiate(bullet, bulletSpawnpoint.transform.position, bulletSpawnpoint.transform.rotation);
        
       // bulletSpawned.rotation = this.transform.rotation;
        }
    public void Die()
    {
        Destroy(this.gameObject);
        // player.GetComponent<PlayerPrefs>().points += pointsToGive; 
    }
	
}
