using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour {

    #region vars
    public bool haveArrow = true; //Do we have the arrow with us
    public GameObject firePoint; //point to fire the arrow from
    public Arrow arrow;
    

    #endregion
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (haveArrow)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 shootDir = firePoint.transform.forward;
                arrow.ShootArrow(shootDir);
                haveArrow = false;
            }
        }
	}
}
