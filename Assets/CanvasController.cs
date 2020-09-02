using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text health;
    public Text score;
    public Text timer;
    public Text nextDemand;
    public Text demandTimer;
    public int difficulty;
    public GameObject letterSpawner;
    public GameObject gameOverScreen;
    void Start()
    {

    }
    void Update()
    {
        if (GlobalData.score >= 1000 && difficulty < 1)
        {
            GlobalData.availableShortcuts.Add("Z");
            letterSpawner.GetComponent<SpawnLetters>().releaseZ = true;
            difficulty++;
        }
        if (GlobalData.score >= 2000 && difficulty < 2)
        {
            GlobalData.availableShortcuts.Add("X");
            letterSpawner.GetComponent<SpawnLetters>().releaseX = true;
            difficulty++;
        }
        if (GlobalData.score >= 3000 && difficulty < 3)
        {
            GlobalData.availableShortcuts.Add("C");
            letterSpawner.GetComponent<SpawnLetters>().releaseC = true;
            difficulty++;
        }
        if (GlobalData.score >= 4000 && difficulty < 4)
        {
            GlobalData.availableShortcuts.Add("V");
            letterSpawner.GetComponent<SpawnLetters>().releaseV = true;
            difficulty++;
        }
        if (GlobalData.score >= 5000 && difficulty < 5)
        {
            GlobalData.availableShortcuts.Add("S");
            letterSpawner.GetComponent<SpawnLetters>().releaseS = true;
            difficulty++;
        }
        if (GlobalData.toggleGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score.text = "SCORE: <b><color=#00AA00>" + GlobalData.score + "</color></b>";
        /*   switch (GlobalData.health)
          {
              case 0:
                  health.text = "HEALTH: <b><color=#FF0000>DEAD</color></b>";
                  break;
              case 1:
                  health.text = "HEALTH: <b><color=#FF0000>♥ </color></b>";
                  break;
              case 2:
                  health.text = "HEALTH: <b><color=#FF0000>♥ ♥</color></b>";
                  break;
              case 3:
                  health.text = "HEALTH: <b><color=#FF0000>♥ ♥ ♥</color></b>";
                  break;

          } */
        if (string.IsNullOrEmpty(GlobalData.nextDemand))
        {
            nextDemand.enabled = false;
            demandTimer.enabled = false;
        }
        else
        {
            if (nextDemand.enabled == false)
            {
                nextDemand.enabled = true;
                demandTimer.enabled = true;
            }
            nextDemand.text = GlobalData.nextDemand;

            demandTimer.text = "in <color=#FF0000><b>" + GlobalData.demandTimer.ToString("F1") + "</b></color>";
        }
        timer.text = GlobalData.timer.ToString("F0");
    }
}
