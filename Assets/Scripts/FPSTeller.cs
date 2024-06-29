using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSTeller : MonoBehaviour
{
    public Text FpsText;

    private float deltaTime;

    private bool update = true;

    void Update()
    {
        float time = PlayerPrefs.GetFloat("FPSTextChange");

        if(update == true)
        {
            update = false;
            Invoke("UpdateFPS", time);
        }
    }

    void UpdateFPS()
    {
        update = true;
        Application.targetFrameRate = PlayerPrefs.GetInt("FPS");
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fps = Mathf.Round(fps * 10.0f) * 0.1f;
        FpsText.text = "FPS: " + fps.ToString();
        //  if (PlayerPrefs.GetFloat("FPS") == Application.targetFrameRate)
        //  {
        //     FpsText.text = "FPS: " + Application.targetFrameRate.ToString();
        //  }
        //  else
        //  {
        //      FpsText.text = "FPS: Unknown";
        //  }
    }
}
