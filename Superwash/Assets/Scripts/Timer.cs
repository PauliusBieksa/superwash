using System;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float initialTime;
    [SerializeField] TextMeshProUGUI textComponent;

    float minutes;
    float seconds;
    float currentTime;

    void Start()
    {
        currentTime = initialTime;

        if (textComponent == null)
        {
            textComponent = GameObject.FindAnyObjectByType<TextMeshProUGUI>().GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        minutes = Mathf.FloorToInt(currentTime / 60F);
        seconds = Mathf.FloorToInt(currentTime - minutes * 60);

        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        textComponent.text = niceTime;
    }

    public void AddTime(float addTime)
    {
        currentTime += addTime;
    }
}
