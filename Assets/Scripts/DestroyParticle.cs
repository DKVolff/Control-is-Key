using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    float destroyTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        destroyTime += Time.deltaTime;
        if (destroyTime >= 3)
        {
            Destroy(gameObject);
        }
    }
}
