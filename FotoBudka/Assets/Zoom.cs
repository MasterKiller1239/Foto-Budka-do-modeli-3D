using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    Camera MainCam;
    private float targetZoom;
    private float zoomFactor = 3.0f;
    private float zoomLerpSpeed = 10.0f;
    private float maxZoom = 90;
    private float minZoom = 30;
    public Slider zoomSlider;
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
        if(targetZoom - scrollData * zoomFactor<= maxZoom && targetZoom - scrollData * zoomFactor >= minZoom)
        {
            targetZoom -= scrollData * zoomFactor;
            zoomSlider.value -= scrollData * zoomFactor;
        }
      
        MainCam.fieldOfView = Mathf.Lerp(MainCam.fieldOfView, targetZoom, Time.deltaTime * zoomLerpSpeed);
        
    }
    public void SliderValueChanged()
    {
        targetZoom = zoomSlider.value;
    }
}
