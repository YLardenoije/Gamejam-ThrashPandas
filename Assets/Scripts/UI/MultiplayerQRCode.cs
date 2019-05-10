using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;

public class MultiplayerQRCode : MonoBehaviour
{
    Texture2D myQR;
    // Start is called before the first frame update
    WebCamTexture camTexture;
    Rect screenRect;
    private enum State { idle = 0, ShowQRCode, ReadQRCode }
    State CurrentState = State.idle;

    void Start()
    {
        CurrentState = State.idle;
        screenRect = new Rect(0, 0, Screen.width, Screen.height / 2);
        camTexture = new WebCamTexture();
        camTexture.requestedHeight = Screen.height / 2;
        camTexture.requestedWidth = Screen.width;
        if (camTexture != null)
        {
            camTexture.Play();
        }


    }
    public void OnGenerateQRCode_BTN_PRESS()
    {
        if (CurrentState == State.ShowQRCode)
        {
            CurrentState = State.idle;
            return;
        }
        CurrentState = State.ShowQRCode;
    }
    public void onReadQRCode_BTN_PRESSED()
    {
        if (CurrentState == State.ReadQRCode)
        {
            CurrentState = State.idle;
            return;
        }
        

       
        CurrentState = State.ReadQRCode;
    }
    void OnGUI()
    {
        if (CurrentState == State.ShowQRCode)
        {
            myQR = generateQR("PITCH at 4 AM. #TAMAFOODCHI");
            
            if (GUI.Button(new Rect(0, 0, 256, 256), myQR, GUIStyle.none)) { }
        }
        if (CurrentState == State.ReadQRCode)
        {
           
            // drawing the camera on screen
            GUI.DrawTexture(screenRect, camTexture, ScaleMode.ScaleToFit);
            // do the reading — you might want to attempt to read less often than you draw on the screen for performance sake
            try
            {
                IBarcodeReader barcodeReader = new BarcodeReader();
                // decode the current frame
                var result = barcodeReader.Decode(camTexture.GetPixels32(), camTexture.width, camTexture.height);
                if (result != null)
                {
                    Debug.Log("DECODED TEXT FROM QR: " + result.Text);
                }
            }
            catch (System.Exception ex) { Debug.LogWarning(ex.Message); }
        }
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
