using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    #region ArrowVars
    public float arrowSpeed;
    public Rigidbody arrowR;
    public Transform arrowStartPosition;
    public ArrowShoot bow;
    public bool isFlying, isReturning;
    public GameObject player; //keep tabs on where the player is so we can easily return the arrow
    public Vector3 arrowCast;
    public Transform arrowTeleport;
    #endregion
    // Use this for initialization
    void Start () {
        
        bow = GameObject.FindGameObjectWithTag("Bow").GetComponent<ArrowShoot>();
        player = GameObject.FindGameObjectWithTag("Player");
        arrowTeleport = transform.GetChild(0);
        
        
        
       
    }
	
	// Update is called once per frame
	void Update () {
        if (isFlying)
        {
            
            
            
            arrowR.transform.rotation = Quaternion.LookRotation(arrowR.velocity);
        }
        else if (isReturning) //This else if statement actually prevent the arrow from being returned unless in has been stopped
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 100 * Time.deltaTime);
        }
	}

    //will need to have a trigger to tell if enemy has been hit and a normal collider to stop the arrow from flying into nothing
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyWeak"))
        {
            //need to figure out how to stop the arrow on death
            Collider arrowCol = GetComponent<Collider>();
            Physics.IgnoreCollision(arrowCol, other, true);
            //other.isTrigger = true;
            Destroy(other.gameObject);

            
            
        }

        if (other.CompareTag("Ground"))
        {
            arrowR.constraints = RigidbodyConstraints.FreezeAll;
            
            
            isFlying = false;
        }

        if (other.CompareTag("Player") || other.CompareTag("Bow"))
        {

            transform.position = GameObject.Find("ArrowSpawnPos").transform.position;
            transform.rotation = GameObject.Find("ArrowSpawnPos").transform.rotation;
            isFlying = false;
            isReturning = false;
            bow.haveArrow = true;
            transform.parent = player.transform;
           



        }
    }

    public void ShootArrow(Vector3 dir)
    {
        //let the arrow move from the bow and allow it dip during an arc
        arrowR.constraints = RigidbodyConstraints.None;
        arrowR.constraints = RigidbodyConstraints.FreezeRotationY;
        arrowR.constraints = RigidbodyConstraints.FreezeRotationZ;
        arrowR.AddForce(dir * arrowSpeed, ForceMode.Impulse);

        
        
        
        //arrowR.velocity = dir * arrowSpeed;
    }

    public void TeleportToArrow()
    {
        arrowR.constraints = RigidbodyConstraints.FreezeAll;
        RaycastHit hit;
        Ray arrowRay = new Ray(arrowTeleport.position, -arrowTeleport.up);
        if (Physics.Raycast(arrowRay, out hit))
        {
            float dist = Vector3.Distance(arrowTeleport.position, hit.point);
            if (dist < 5f)
            {
                Vector3 offset = new Vector3(0, 1f, 0);
                player.transform.position = arrowTeleport.position;
                player.transform.position += offset;
            } else
            {
                player.transform.position = arrowTeleport.position;
            }
        }

        transform.position = GameObject.Find("ArrowSpawnPos").transform.position;
        transform.rotation = GameObject.Find("ArrowSpawnPos").transform.rotation;

        isFlying = false;
        isReturning = false;
        bow.haveArrow = true;
       

        transform.parent = player.transform;
    }
}
