using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour {

    public int enemyCount;
    public GUIStyle textStyle;
    public PauseManager pauseManager;
    
	// Use this for initialization
	void Start () {
        enemyCount= GameObject.Find("Enemies").transform.childCount;
        pauseManager = GameObject.FindGameObjectWithTag("PauseManager").GetComponent<PauseManager>();
    }
	
	// Update is called once per frame
	void Update () {
		if(enemyCount == 0)
        {
            Invoke("LevelChange", 5f);
        }
	}

    private void OnGUI()
    {
        if (!pauseManager.isPaused)
        {
            float scrW = Screen.width / 16;
            float scrH = Screen.height / 9;

            GUI.Box(new Rect(scrW, 0.25f * scrH, 3f * scrW, scrH * 0.75f), "Enemies: " + enemyCount);

            if (enemyCount == 0)
            {

                GUI.Box(new Rect(scrW * 6f, 3.5f * scrH, 4f * scrW, scrH * 1f), "LEVEL CLEARED", textStyle);

            }
        }
    }

    public void LevelChange()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
