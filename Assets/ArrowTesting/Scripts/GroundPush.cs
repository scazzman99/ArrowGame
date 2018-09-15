using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPush : MonoBehaviour {

    public Transform telepoint, teleStart;
    public Vector3 norm;

	// Use this for initialization
	void Start () {
        telepoint = transform.GetChild(0);
        teleStart = transform.GetChild(1);
        norm = telepoint.position - teleStart.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float dist = Vector3.Distance(teleStart.position, telepoint.position);
            collision.transform.position += norm;
        }
    }


}
