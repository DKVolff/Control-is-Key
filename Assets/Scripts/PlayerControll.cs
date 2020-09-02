using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject linePrefab;
    public GameObject currentLine;
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> playerPositions;
    public List<Vector2> edgePositions;
    public GameObject polygonObject;
    public PolygonCollider2D polygonCollider;
    public List<Vector2> polyPositions;
    public GameObject pointAPrefab;
    public LayerMask pointAMask;
    public ParticleSystem captureParticlesS;
    public ParticleSystem captureParticlesN;
    public ParticleSystem captureParticlesB;
    public int moveSpeed;
    public bool speedModifier;
    public float speedModifierTimer;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (!GlobalData.toggleGameOver)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                CreateLine();

            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                Vector2 tempPlayerPos = transform.position;
                if (Vector2.Distance(tempPlayerPos, playerPositions[playerPositions.Count - 1]) > 0.5f)
                {
                    FindObjectOfType<AudioManager>().Play("Draw");
                    UpdateLine(tempPlayerPos);
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftControl) && currentLine != null)
            {
                try
                {
                    if (Physics2D.OverlapCircle(transform.position, 2f, pointAMask).shapeCount > 0)
                    {
                        var newCapture = Instantiate(polygonObject, currentLine.transform);
                        currentLine.GetComponent<LifeTime>().startLifetime = true;
                        newCapture.GetComponent<PolygonCollider2D>().points = edgeCollider.points;
                        foreach (var point in edgeCollider.points)
                        {
                            Instantiate(captureParticlesS, point + (Vector2)currentLine.transform.localPosition, Quaternion.identity);
                            Instantiate(captureParticlesN, point + (Vector2)currentLine.transform.localPosition, Quaternion.identity);
                            Instantiate(captureParticlesB, point + (Vector2)currentLine.transform.localPosition, Quaternion.identity);
                        }
                    }
                }
                catch
                {

                    Destroy(currentLine);
                }
            }

            /*      if (speedModifier)
                 {
                     speedModifierTimer += Time.deltaTime;
                     if (speedModifierTimer >= 3)
                     {
                         moveSpeed = 10;
                         speedModifierTimer = 0;
                         speedModifier = false;
                     }
                 } */
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            rb.velocity = Vector2.zero;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GlobalData.toggleGameOver)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);

            rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * moveSpeed);
        }
    }

    void CreateLine()
    {
        currentLine = Instantiate(linePrefab, transform.position, Quaternion.identity);
        Instantiate(pointAPrefab, transform.position, Quaternion.identity, currentLine.transform);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        playerPositions.Clear();
        edgePositions.Clear();
        playerPositions.Add(transform.position);
        playerPositions.Add(transform.position);
        lineRenderer.SetPosition(0, playerPositions[0]);
        lineRenderer.SetPosition(1, playerPositions[1]);
        edgeCollider.points = edgePositions.ToArray();
        for (var i = 0; i < playerPositions.Count; i++)
        {
            edgeCollider.points[i] = lineRenderer.GetPosition(i) - lineRenderer.GetPosition(0);

        }
    }

    void UpdateLine(Vector2 newPlayerPos)
    {
        try
        {
            playerPositions.Add(newPlayerPos);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPlayerPos);

            edgePositions.Clear();

            for (var i = 0; i < lineRenderer.positionCount; i++)
            {
                edgePositions.Add(lineRenderer.GetPosition(i) - lineRenderer.GetPosition(0));
                //   newpos.Add(lineRenderer.GetPosition(i) - lineRenderer.GetPosition(0));

            }
            edgeCollider.points = edgePositions.ToArray();
        }
        catch
        {

        }


    }
}
