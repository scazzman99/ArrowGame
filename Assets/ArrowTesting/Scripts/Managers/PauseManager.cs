using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {


    public bool isPaused; //bool to pull up pause menu and stop camera movement
    public GameObject pauseMenu; //attached thru editor
	// Use this for initialization
	void Start () {
        //on scene reload this will ensure nothing breaks horribly
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
	
	// Update is called once per frame
	void Update () {
        //check if the pause key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PauseGame();
        }

        
	}

    void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Resume()
    {
        isPaused = false;
        PauseGame();
    }

    public void ExitGame()
    {
        
        SceneManager.LoadScene(0);
    }
}
