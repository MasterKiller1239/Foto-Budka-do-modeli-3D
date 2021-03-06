using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Globalization;
using System;
using UnityEngine.UI;

public class ScreenShotMaker : MonoBehaviour
{

    public int superSize = 1;
    string localDate;
    string destination;
    public Text notificationText;
    private void Start()
    {
        destination = Application.dataPath + "/StreamingAssets/Output/";
    }
    public void TakeScreenShot()
    {
         localDate = DateTime.Now.ToString();
        localDate = localDate.Replace("/", "-");
        localDate = localDate.Replace(" ", "_");
        localDate = localDate.Replace(":", "-");
       
        StartCoroutine(CaptureScreen());
    }

 
    public IEnumerator CaptureScreen()
    {
        // Wait till the last possible moment before screen rendering to hide the UI
        yield return null;
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;

        // Wait for screen rendering to complete
        yield return new WaitForEndOfFrame();

        // Take screenshot
        ScreenCapture.CaptureScreenshot(destination + $"Screenshot from {localDate}.png", superSize);

        // Show UI after we're done
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;

        notificationText.text = "Saved to " + destination + $"Screenshot from {localDate}.png";
        yield return new WaitForSeconds(5);
        notificationText.text = "";

    }



}
