using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScalerScript : MonoBehaviour
{
    float canvasScale;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<CanvasScaler>().scaleFactor = Screen.height / 1080f;
    }
}