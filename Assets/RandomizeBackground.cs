using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeBackground : MonoBehaviour
{
    public int depth;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        transform.position = new Vector3(Random.Range(-50, 100), Random.Range(-50, 50), depth);
        transform.localScale = new Vector3(Random.Range(5, 25), Random.Range(5, 25), 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
