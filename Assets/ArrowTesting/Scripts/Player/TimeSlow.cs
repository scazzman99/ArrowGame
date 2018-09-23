using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlow : MonoBehaviour {

    public float timeMax = 5f;
    public float timeCurrent;
    public float timeModify = 0.05f;
    public bool canSlow = true;
    public bool isSlowed;
    public GUIStyle timeBar;
    public float originalFixedDelta;
	// Use this for initialization
	void Start () {
        timeCurrent = timeMax;
        originalFixedDelta = Time.fixedDeltaTime;
	}

    // Update is called once per frame
    private void Update()
    {
        if (canSlow)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (!isSlowed)
                {
                    SlowDown();
                }
                timeCurrent -= Time.unscaledDeltaTime;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Time.timeScale = 1;
                Time.fixedDeltaTime = originalFixedDelta;
            }
        }
    }

    private void LateUpdate()
    {
        if(timeCurrent <= 0)
        {
            canSlow = false;
            timeCurrent = 0;
            Time.timeScale = 1;
        }
    }


    void SlowDown()
    {
        Time.timeScale = timeModify;
        Time.fixedDeltaTime = Time.timeScale * 0.02f; //physics will work off of fixed delta, 02 is standard
    }

    private void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        //Set up bar for time
        //background bar
        GUI.Box(new Rect(scrW * 6f, scrH * 0.25f, scrW * 4, scrH * 0.75f), "");
        GUI.Box(new Rect(scrW * 6f, scrH * 0.25f, (scrW * 4 * timeCurrent) / timeMax, scrH * 0.75f), "", timeBar);
    }
}
