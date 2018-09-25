using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int playerHP;
    public bool isAlive = true;
    public GUIStyle health;
    public PauseManager pauseManager;
    public CharacterController playerControl;
	// Use this for initialization
	void Start () {
        playerHP = 3;
        pauseManager = GameObject.FindGameObjectWithTag("PauseManager").GetComponent<PauseManager>();
        playerControl = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        if(playerHP == 0)
        {
            isAlive = false;
            playerControl.enabled = false;
            RestartLevel();
        }
    }

    private void OnGUI()
    {
        if (!pauseManager.isPaused) {
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

    //reload the scene
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
