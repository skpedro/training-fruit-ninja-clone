using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    public AudioSource audio;

    public void Stop()
    {
        audio.Stop();
        panel.SetActive(true);
        Time.timeScale = 0;
    }
}
