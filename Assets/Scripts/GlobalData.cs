using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    // Start is called before the first frame update
    public static int health = 3;
    public static int score = 0;
    public static float timer = 60;
    public static int limitSpawnA = 30;
    public static int limitSpawnZ = 27;
    public static int limitSpawnX = 24;
    public static int limitSpawnC = 20;
    public static int limitSpawnV = 18;
    public static int limitSpawnS = 15;
    public static List<string> availableShortcuts = new List<string>();
    public static string nextDemand;
    public static float demandTimer = 10;
    public static float timeBetweenDemands = 5;
    public static bool toggleGameOver;

    void Start()
    {
        health = 3;
        score = 0;
        timer = 60;
        availableShortcuts.Clear();
        demandTimer = 10;
        timeBetweenDemands = 5;
        toggleGameOver = false;
        availableShortcuts.Add("A");
        nextDemand = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!toggleGameOver)
        {
            timer -= Time.deltaTime;
            timeBetweenDemands -= Time.deltaTime;
        }
        if (timeBetweenDemands <= 0 && string.IsNullOrEmpty(nextDemand))
        {
            nextDemand = availableShortcuts[Random.Range(0, availableShortcuts.Count)];
        }
        if (!string.IsNullOrEmpty(nextDemand) && !toggleGameOver)
        {
            demandTimer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            toggleGameOver = true;
        }
        if (demandTimer <= 0)
        {
            toggleGameOver = true;
        }
    }
}
