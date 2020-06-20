using System.Collections;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    Rect fpsRect;
    GUIStyle style;
    float fps;

    void Start()
    {
        Application.targetFrameRate = 30;


        fpsRect = new Rect(50, 50, 200, 50);
        style = new GUIStyle();
        style.fontSize = 24;

        StartCoroutine(RecalculateFPS());
    }

    private IEnumerator RecalculateFPS()
    {
        while (true)
        {
            fps = 1 / Time.deltaTime;
            yield return new WaitForSeconds(1);
        }
    }

    private void OnGUI()
    {
        //float fps = 1 / Time.deltaTime;
        GUI.Label(fpsRect, "FPS: " + string.Format("{0:0.0}", fps), style);
    }
}
