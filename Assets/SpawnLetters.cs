using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLetters : MonoBehaviour
{
    public GameObject APrefab;
    public GameObject ZPrefab;
    public GameObject XPrefab;
    public GameObject CPrefab;
    public GameObject VPrefab;
    public GameObject SPrefab;
    public float timeSpawnA;
    public float timeSpawnZ;
    public float timeSpawnX;
    public float timeSpawnC;
    public float timeSpawnV;
    public float timeSpawnS;
    public bool releaseA;
    public bool releaseZ;
    public bool releaseX;
    public bool releaseC;
    public bool releaseV;
    public bool releaseS;
    List<GameObject> spawnedA = new List<GameObject>();
    List<GameObject> spawnedZ = new List<GameObject>();
    List<GameObject> spawnedX = new List<GameObject>();
    List<GameObject> spawnedC = new List<GameObject>();
    List<GameObject> spawnedV = new List<GameObject>();
    List<GameObject> spawnedS = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            CleanUp();
        }
        catch
        {

        }
        timeSpawnA += Time.deltaTime;
        timeSpawnZ += Time.deltaTime;
        timeSpawnX += Time.deltaTime;
        timeSpawnC += Time.deltaTime;
        timeSpawnV += Time.deltaTime;
        timeSpawnS += Time.deltaTime;
        if (releaseA && timeSpawnA > .1f && spawnedA.Count < GlobalData.limitSpawnA)
        {
            spawnedA.Add(Instantiate(APrefab, new Vector2(Random.Range(-45, 95), Random.Range(-45, 45)), Quaternion.identity));
            timeSpawnA = 0;
        }
        if (releaseZ && timeSpawnZ > .1f && spawnedZ.Count < GlobalData.limitSpawnZ)
        {
            spawnedZ.Add(Instantiate(ZPrefab, new Vector2(Random.Range(-45, 95), Random.Range(-45, 45)), Quaternion.identity));
            timeSpawnZ = 0;
        }
        if (releaseX && timeSpawnX > .1f && spawnedX.Count < GlobalData.limitSpawnX)
        {
            spawnedX.Add(Instantiate(XPrefab, new Vector2(Random.Range(-45, 95), Random.Range(-45, 45)), Quaternion.identity));
            timeSpawnX = 0;
        }

        if (releaseC && timeSpawnC > .1f && spawnedC.Count < GlobalData.limitSpawnC)
        {
            spawnedC.Add(Instantiate(CPrefab, new Vector2(Random.Range(-45, 95), Random.Range(-45, 45)), Quaternion.identity));
            timeSpawnC = 0;
        }

        if (releaseV && timeSpawnV > .1f && spawnedV.Count < GlobalData.limitSpawnV)
        {
            spawnedV.Add(Instantiate(VPrefab, new Vector2(Random.Range(-45, 95), Random.Range(-45, 45)), Quaternion.identity));
            timeSpawnV = 0;
        }

        if (releaseS && timeSpawnS > .1f && spawnedS.Count < GlobalData.limitSpawnS)
        {
            spawnedS.Add(Instantiate(SPrefab, new Vector2(Random.Range(-45, 95), Random.Range(-45, 45)), Quaternion.identity));
            timeSpawnS = 0;
        }
    }

    void CleanUp()
    {
        foreach (var a in spawnedA)
        {
            if (a == null)
            {
                spawnedA.Remove(a);
            }
        }
        
        foreach (var z in spawnedZ)
        {
            if (z == null)
            {
                spawnedZ.Remove(z);
            }
        }
        
        foreach (var x in spawnedX)
        {
            if (x == null)
            {
                spawnedX.Remove(x);
            }
        }
        
        foreach (var c in spawnedC)
        {
            if (c == null)
            {
                spawnedC.Remove(c);
            }
        }
        
        foreach (var v in spawnedV)
        {
            if (v == null)
            {
                spawnedV.Remove(v);
            }
        }
        
        foreach (var s in spawnedS)
        {
            if (s == null)
            {
                spawnedS.Remove(s);
            }
        }
    }
}
