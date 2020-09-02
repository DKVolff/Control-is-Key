using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float lifeTime;
    public bool startLifetime;
    public GameObject screenFlashPrefab;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startLifetime)
        {
            lifeTime -= Time.deltaTime;
        }
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.layer == 12)
        {
            GlobalData.timer -= 3;
            FindObjectOfType<AudioManager>().Play("Damage");
            Instantiate(screenFlashPrefab, hitInfo.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
