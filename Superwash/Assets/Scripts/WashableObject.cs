using UnityEngine;
using System.Collections.Generic;

public class WashableObject : MonoBehaviour
{
    public string objectName;
    public Sprite cleanSprite;
    public bool isClean = false;
    public GameObject dirt;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cleanSprite;
    }

    private void Update()
    {
        if (!isClean)
        {
            if (dirt.GetComponent<Dirt>().cleaningDistance >= dirt.GetComponent<Dirt>().dirtCleaningDistanceRSum[dirt.GetComponent<Dirt>().dirtCleaningDistanceRSum.Count - 1])
            {
                isClean = true;
                dirt.SetActive(false);
            }
        }
    }
}
