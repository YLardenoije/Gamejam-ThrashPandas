﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;

public class QrHandler : MonoBehaviour
{
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

    void OnGUI()
    {
        var myQR = generateQR("google.com");
        if (GUI.Button(new Rect(300, 300, 256, 256), myQR, GUIStyle.none)) { }
        // drawing the camera on screen
        GUI.DrawTexture(screenRect, camTexture, ScaleMode.ScaleToFit);
        // do the reading — you might want to attempt to read less often than you draw on the screen for performance sake
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            // decode the current frame
            var result = barcodeReader.Decode(camTexture.GetPixels32(),
              camTexture.width, camTexture.height);
            if (result != null)
            {
                Debug.Log("DECODED TEXT FROM QR: " +result.Text);
            }
        }
        catch (System.Exception ex) { Debug.LogWarning(ex.Message); }
    }
    public static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }
    public Texture2D generateQR(string text)
    {
        var encoded = new Texture2D(256, 256);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }

}