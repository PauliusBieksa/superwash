using System;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;

    float minutes;
    float seconds;
    float currentTime;

    void Start()
    {
        currentTime = 0;
        if (textComponent == null)
        {
            textComponent = GameObject.FindAnyObjectByType<TextMeshProUGUI>().GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime % 60F);
        int milliseconds = Mathf.FloorToInt((currentTime * 1000F) % 1000F);

        string niceTime = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        textComponent.text = niceTime;
    }


    public float TimeElapsed()
    {
        return currentTime;
    }
}
