using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    #region ArrowVars
    public float arrowSpeed;
    public Rigidbody arrowR;
    public Transform arrowStartPosition;
    public ArrowShoot bow;
    public bool isFlying, isReturning;
    public GameObject player; //keep tabs on where the player is so we can easily return the arrow
    public Vector3 arrowCast;
    public Transform arrowTeleport, collCheck;
    public float stepDist = 10f;
    public EnemyCounter enemyCounter;

    #endregion
    // Use this for initialization
    void Start()
    {

        bow = GameObject.FindGameObjectWithTag("Bow").GetComponent<ArrowShoot>();
        player = GameObject.FindGameObjectWithTag("Player");
        arrowTeleport = transform.GetChild(0);
        enemyCounter = GameObject.Find("Enemies").GetComponent<EnemyCounter>();




    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFlying)
        {
            //change the look direction of the arrow to its velocity
            arrowR.transform.rotation = Quaternion.LookRotation(arrowR.velocity);
            Vector3 arrowForward = arrowR.velocity;
            arrowForward.Normalize();
            RaycastHit hit;
            //use a Linecast to see if the arrow will hit anything in front of it. If so and it is not an enemy, stop the arrow.
            if(Physics.Linecast(transform.position, transform.position + arrowR.velocity * stepDist * Time.fixedDeltaTime, out hit))
            {
                if (hit.collider.tag == "Ground")
                {
                    //get the rotation of the arrow
                    Quaternion arrowRotation = transform.rotation;
                    //get the normal of the object being hit

                   // Vector3 normalPos = hit.normal;
                    //normalPos.Normalize();

                    //freeze the arrow
                    arrowR.isKinematic = true;
                    //move arrow to slightly off the hit point
                    arrowR.MovePosition(hit.point);
                    arrowR.MoveRotation(arrowRotation);
                    isFlying = false;
                    Debug.Log("Ray HIT!");
                }
                //This check is here to stop the arrow from deflecting after enemy is dead (didnt work lol)
                else if(hit.collider.tag == "ArmourWeak")
                {
                    arrowR.MovePosition(hit.point);
                    Destroy(hit.transform.parent.gameObject);
                    enemyCounter.enemyCount--;
                    isFlying = false;
                    Debug.Log("Hit WEAKSPOT");
                }
            }
            


        }
        else if (isReturning) //This else if statement actually prevent the arrow from being returned unless in has been stopped
        {
            arrowR.isKinematic = false;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 100f * Time.deltaTime);
        }
    }

    //will need to have a trigger to tell if enemy has been hit and a normal collider to stop the arrow from flying into nothing
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("EnemyWeak"))
        {

            Destroy(other.gameObject);
            enemyCounter.enemyCount--;
        }

        if (other.CompareTag("Ground"))
        {
            isFlying = false;
            print("HitWall");



        }

        if (other.CompareTag("Player") && bow.haveArrow == false && !isFlying)
        {
            bow.haveArrow = true;
            bow.arrow = null;
            Destroy(this.gameObject);

        }

        /*
         * if (other.CompareTag("ArmourWeak"))
        {
            GameObject armourParent = other.transform.parent.gameObject;
            Debug.Log("Hit WEAK SPOT");
            Destroy(armourParent);
        }
        */

        if (other.CompareTag("Armour"))
        {
            Debug.Log("Hit ARMOUR");
            arrowR.velocity = Vector3.zero;
           
        }
    }



    public void ShootArrow(Vector3 dir)
    {
        
        arrowR.AddForce(dir * arrowSpeed, ForceMode.Impulse);
        arrowR.constraints = RigidbodyConstraints.FreezePosition;
        arrowR.constraints = RigidbodyConstraints.FreezeRotationZ;
        arrowR.constraints = RigidbodyConstraints.FreezeRotationY;
        isFlying = true;

    }

    public void TeleportToArrow()
    {
        arrowR.velocity = Vector3.zero;
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
            }
            else
            {
                player.transform.position = arrowTeleport.position;
            }
        }



        bow.haveArrow = true;
        bow.arrow = null;

        Destroy(this.gameObject);
    }
}
