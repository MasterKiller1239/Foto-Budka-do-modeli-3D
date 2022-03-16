using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    Camera MainCam;
    private float targetZoom;
    private float zoomFactor = 3.0f;
    private float zoomLerpSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        MainCam = Camera.main;
        targetZoom = MainCam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");
        targetZoom -= scrollData * zoomFactor;
        MainCam.fieldOfView = Mathf.Lerp(MainCam.fieldOfView, targetZoom, Time.deltaTime * zoomLerpSpeed);
        
    }
}
