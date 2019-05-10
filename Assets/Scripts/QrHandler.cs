using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
using UnityEngine.SceneManagement;

public class QrHandler : MonoBehaviour
{
    [SerializeField] SOStats stats;
    [SerializeField] Text text;
    // Start is called before the first frame update


    private WebCamTexture camTexture;
    private Rect screenRect;
    void Start()
    {
       
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
       
        camTexture = new WebCamTexture();
        camTexture.requestedHeight = Screen.height;
        camTexture.requestedWidth = Screen.width;
        if (camTexture != null)
        {
            camTexture.Play();
            
        }
    
       
        
    }

    private void OnDestroy()
    {
        camTexture.Stop();
    }

    void OnGUI()
    {
       
        // drawing the camera on screen
        GUI.DrawTexture(screenRect, camTexture, ScaleMode.ScaleToFit);
        // do the reading — you might want to attempt to read less often than you draw on the screen for performance sake
        if (Time.frameCount % 20 == 0)
        {
            try
            {
                IBarcodeReader barcodeReader = new BarcodeReader();
                // decode the current frame
                var result = barcodeReader.Decode(camTexture.GetPixels32(),
                  camTexture.width, camTexture.height);
                if (result != null)
                {
                    Debug.Log("DECODED TEXT FROM QR: " + result.Text);
                    stats.addHunger(Convert.ToInt32(result.Text));
                    text.enabled = true;
                    Debug.Log("below enabled");
                }
            }
            catch (System.Exception ex) { Debug.LogWarning(ex.Message); }
        }
    }
   

}
