using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    #region ArrowVars
    public float arrowSpeed;
    public Rigidbody arrowR;
    public GameObject bow;
    #endregion
    // Use this for initialization
    void Start () {
        bow = GameObject.FindGameObjectWithTag("Bow");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //will need to have a trigger to tell if enemy has been hit and a normal collider to stop the arrow from flying into nothing
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyWeak"))
        {
            //need to figure out how to stop the arrow on death
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            arrowR.constraints = RigidbodyConstraints.FreezeAll;
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
}
