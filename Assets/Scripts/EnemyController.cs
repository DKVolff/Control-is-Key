using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool enableTimeDestroy = false;
    public GameObject screenFlashPrefab;
    public float timeDestroy = 0;
    public GameObject emptyKeyPrefab;
    Vector2 moveDir;
    public Rigidbody2D rb;
    public float moveSpeed;
    float changeDirections;
    public float changeDirectionsFrequency;
    public bool hasToWait;
    public float waitTime;
    public bool followsPlayer;
    public GameObject player;
    public bool teleports;
    public GameObject damageSound;
    // Start is called before the first frame update
    void Start()
    {

        if (gameObject.name[0] == 'X' || gameObject.name[0] == 'S')
        {
            hasToWait = true;
        }


        if (gameObject.name[0] == 'C')
        {
            followsPlayer = true;
            player = GameObject.Find("Player");
        }
        if (gameObject.name[0] == 'S')
        {
            teleports = true;
            player = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        changeDirections += Time.deltaTime;
        try
        {
            if (followsPlayer)
            {
                moveDir = player.transform.localPosition - transform.position;
            }
            else
            {
                if (changeDirections > changeDirectionsFrequency)
                {
                    moveDir = new Vector2(Mathf.RoundToInt(Random.Range(-1.99f, 1.99f)), Mathf.RoundToInt(Random.Range(-1.99f, 1.99f))).normalized;
                    changeDirections = 0;
                }
            }
        }
        catch
        {

        }


        if (enableTimeDestroy)
        {
            timeDestroy += Time.deltaTime;
            if (timeDestroy >= 1)
            {
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        if (!hasToWait)
        {
            rb.MovePosition(rb.position + moveDir.normalized * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            if (waitTime >= 0)
            {
                waitTime -= Time.deltaTime;
            }
            else
            {
                if (teleports)
                {

                    waitTime -= Time.deltaTime;
                    if (waitTime <= -10)
                    {
                        transform.position = new Vector2(Random.Range(-45, 95), Random.Range(-45, 45));
                        waitTime = 10;
                    }
                }
                else
                {
                    waitTime -= Time.deltaTime;
                    rb.MovePosition(rb.position + moveDir.normalized * moveSpeed * Time.fixedDeltaTime);
                    if (waitTime <= -3)
                    {
                        waitTime = 3;
                    }
                }
            }
        }

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.name == "CaptureCollider(Clone)")
        {
            moveSpeed = 0;
            enableTimeDestroy = true;
            GlobalData.score += 100;
            if (gameObject.name[0] == 'S')
            {
                GlobalData.score += 500;
            }
            if (GlobalData.timer < 94)
            {
                GlobalData.timer += 3;
            }
            else
            {
                GlobalData.timer = 99;
            }
            Instantiate(emptyKeyPrefab, transform.position, Quaternion.identity, transform);

            FindObjectOfType<AudioManager>().Play("Capture");
            if (gameObject.name[0].ToString() == GlobalData.nextDemand)
            {
                GlobalData.score += 200;
                GlobalData.timer += 2;
                GlobalData.nextDemand = null;
                GlobalData.timeBetweenDemands = 5;
                GlobalData.demandTimer = 10;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.name == "Player")
        {
            GlobalData.timer -= 5;
            FindObjectOfType<AudioManager>().Play("Damage");
            Instantiate(screenFlashPrefab, hitInfo.gameObject.transform.position, Quaternion.identity);
            hitInfo.gameObject.transform.position += (hitInfo.transform.position - gameObject.transform.position) * 1.5f;
            hitInfo.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
