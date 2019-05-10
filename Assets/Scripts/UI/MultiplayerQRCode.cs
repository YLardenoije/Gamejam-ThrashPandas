using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class MultiplayerQRCode : MonoBehaviour
{
    [SerializeField] private Text ChallengeTextBox;
    [SerializeField] private Challenge challenge; 
    [SerializeField] private SOStats stats;
    Texture2D myQR;
    // Start is called before the first frame update
    WebCamTexture camTexture;
    Rect screenRect;
    private enum State { idle = 0, ShowQRCode, ReadQRCode }
    State CurrentState = State.idle;

    void Start()
    {
        stats.ClearValues();
        ChallengeTextBox.text = challenge.ToString();
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
            myQR = generateQR(stats.AnimalType + "," + stats.Happiness + "," + stats.Hunger +"," + stats.SocialRating+ "," + stats.XP);
            
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
                    challenge.CheckForCompletion(result.Text);
                    ChallengeTextBox.text = challenge.ToString();
                    
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
