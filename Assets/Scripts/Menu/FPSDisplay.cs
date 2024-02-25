using UnityEngine;
using System.Collections;

public class FPSDisplay : MonoBehaviour
{
    private float deltaTime = 0.0f;
    public int fontSize;
    public float red;
    public float green;
    public float blue;
    public float opacity;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = h * fontSize / 100;
        style.normal.textColor = new Color(red, green, blue, opacity);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{1:0.} fps", msec, fps);
        GUI.Label(rect, text, style);
    }
}