using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour {

    #region vars
    public bool haveArrow = true; //Do we have the arrow with us
    public GameObject firePoint; //point to fire the arrow from
    public Arrow arrow;
    public GameObject arrowP;
    public Transform spawnP;
    
    

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
                Ray camRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2f, Screen.height/2f)); //shoot a ray out from centre of screen
                

                Vector3 fireDir = camRay.direction;
                    fireDir.Normalize();
                GameObject clone = Instantiate(arrowP, spawnP.position, spawnP.rotation);
                arrow = clone.GetComponent<Arrow>();
                    arrow.ShootArrow(fireDir);
                    haveArrow = false;
                    arrow.isFlying = true;
                   
                
               
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                arrow.arrowR.velocity = Vector3.zero;
                arrow.isReturning = true;
                arrow.isFlying = false;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                arrow.TeleportToArrow(); //arrow script has players position stored
            }
        }
        

        
	}

    


}
