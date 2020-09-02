using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPad : MonoBehaviour
{
    public float downtime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            if (downtime >= 0)
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
                downtime -= Time.deltaTime;
            }
            else
            {

                gameObject.GetComponent<Collider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.name == "Player")
        {
            
            FindObjectOfType<AudioManager>().Play("Slow");
            // hitInfo.gameObject.GetComponent<PlayerControll>().speedModifier = true;
            if (hitInfo.gameObject.GetComponent<PlayerControll>().moveSpeed > 5)
            {
                hitInfo.gameObject.GetComponent<PlayerControll>().moveSpeed--;
            }
            if (hitInfo.gameObject.GetComponent<PlayerControll>().moveSpeed > 10)
            {
                hitInfo.gameObject.GetComponent<PlayerControll>().moveSpeed--;
            }
            if (hitInfo.gameObject.GetComponent<PlayerControll>().moveSpeed > 20)
            {
                hitInfo.gameObject.GetComponent<PlayerControll>().moveSpeed--;
            }
            if (hitInfo.gameObject.GetComponent<PlayerControll>().moveSpeed > 15)
            {
                hitInfo.gameObject.GetComponent<PlayerControll>().moveSpeed--;
            }
            if (hitInfo.gameObject.GetComponent<PlayerControll>().moveSpeed > 10)
            {
                hitInfo.gameObject.GetComponent<PlayerControll>().moveSpeed--;
            }
            hitInfo.gameObject.GetComponent<PlayerControll>().speedModifierTimer = 0;
            downtime = 3;

        }
    }
}
