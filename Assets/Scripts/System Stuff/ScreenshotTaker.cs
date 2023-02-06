using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using System.IO;

public class ScreenshotTaker : MonoBehaviour
{
    string directory;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        directory = Application.dataPath + "\\..\\Screenshots";
    }

    void TakeScreenshot()
    {
        if (!Directory.Exists(directory))
        {
            try
            {
                Directory.CreateDirectory(directory);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to create directory: \"" + directory + "\r\n" + e);
                return;
            }
        }

        string path = directory + "\\" +
            DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff") + ".png";
        ScreenCapture.CaptureScreenshot(path);
        Debug.Log("Screenshot saved to \"" + path + "\"");
    }

    public void HandleScreenshot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            TakeScreenshot();
        }
    }
}
