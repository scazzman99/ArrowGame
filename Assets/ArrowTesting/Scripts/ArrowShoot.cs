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
                Ray camRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2)); //shoot a ray out from centre of screen
                RaycastHit info;
                if(Physics.Raycast(camRay, out info, 300f))
                {
                    Vector3 fireDir = info.point - firePoint.transform.position;
                    fireDir.Normalize();
                    arrow.ShootArrow(fireDir);
                    haveArrow = false;
                }
               
            }
        }
	}


}
