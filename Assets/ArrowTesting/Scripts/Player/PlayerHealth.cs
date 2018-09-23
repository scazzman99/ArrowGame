using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int playerHP;
    public bool isAlive = true;
    public GUIStyle health;
	// Use this for initialization
	void Start () {
        playerHP = 3;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        float scrW = Screen.width / 16f;
        float scrH = Screen.height / 9f;

        if (playerHP != 0)
        {


            GUI.Box(new Rect(scrW * 12f, scrH * 0.25f, scrW, scrH * 0.75f), "");
            GUI.Box(new Rect(scrW * 13f, scrH * 0.25f, scrW, scrH * 0.75f), "");
            GUI.Box(new Rect(scrW * 14f, scrH * 0.25f, scrW, scrH * 0.75f), "");
            if (playerHP > 2)
            {
                GUI.Box(new Rect(scrW * 14f, scrH * 0.25f, scrW, scrH * 0.75f), "", health);
            }
            if (playerHP > 1)
            {
                GUI.Box(new Rect(scrW * 13f, scrH * 0.25f, scrW, scrH * 0.75f), "", health);
            }
            if (playerHP > 0)
            {
                GUI.Box(new Rect(scrW * 12f, scrH * 0.25f, scrW, scrH * 0.75f), "", health);
            }

        }
    }
}
