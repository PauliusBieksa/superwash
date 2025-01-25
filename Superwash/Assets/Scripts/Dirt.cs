using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    public List<Sprite> dirtSprites;
    public List<float> dirtCleaningDistance;
    public List<float> dirtCleaningDistanceRSum;
    public float cleaningDistance;
    public int spriteIndex;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < dirtCleaningDistance.Count; i++)
        {
            if (i > 0)
            {
                dirtCleaningDistanceRSum.Add(dirtCleaningDistanceRSum[i - 1] + dirtCleaningDistance[i]);
            }
            else
            {
                dirtCleaningDistanceRSum.Add(dirtCleaningDistance[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < dirtCleaningDistance.Count; i++)
        {
            if (cleaningDistance < dirtCleaningDistanceRSum[0])
            {
                spriteIndex = 0;
            }

            if (i > 0)
            {
                if (cleaningDistance > dirtCleaningDistanceRSum[i - 1] && cleaningDistance < dirtCleaningDistanceRSum[i])
                {
                    spriteIndex = i;
                }
            }

        }

        spriteRenderer.sprite = dirtSprites[spriteIndex];
    }
}
