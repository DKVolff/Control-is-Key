using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadSpawner : MonoBehaviour
{
    public GameObject padPrefab;
    float timeSpawnPad;
    int currentPads = 0;
    int padLimit;
    public int startingMaxPad;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeSpawnPad += Time.deltaTime;
        padLimit = (GlobalData.score / 50) + startingMaxPad;
        if (timeSpawnPad >= 1f && currentPads < padLimit)
        {
            Instantiate(padPrefab, new Vector2(Random.Range(-45, 95), Random.Range(-45, 45)), Quaternion.identity);
            currentPads++;
            timeSpawnPad = 0;
        }
    }
}
