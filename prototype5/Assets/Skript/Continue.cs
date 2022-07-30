using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    public GameObject panel;
    public AudioSource audio;
    public void ContinueMethod()
    {
        audio.Play();
        Time.timeScale = 1f;
        panel.SetActive(false);
    }
}
