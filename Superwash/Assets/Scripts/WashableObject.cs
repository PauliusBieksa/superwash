using UnityEngine;
using System.Collections.Generic;

public class WashableObject : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer dirt_sprite_renderer;
    [SerializeField]
    List<Sprite> dirt_sprites;
    [SerializeField]
    List<float> dist_to_clean;

    int dirt_level = 0;
    float dist_cleaned = 0f;


    public bool is_clean = false;

    void Start()
    {

    }

    private void Update()
    {

    }

    public void clean(float dist)
    {
        dist_cleaned += dist;
        float threshold = 0f;
        for (int i = 0; i < dist_to_clean.Count; i++)
        {
            threshold += dist_to_clean[i];
            if (dist_cleaned < threshold)
            {
                if (dirt_level != i)
                {
                    dirt_level = i;
                    dirt_sprite_renderer.sprite = dirt_sprites[i];
                    break;
                }
            }
        }
        if (dist_cleaned > threshold)
        {
            is_clean = true;
            dirt_sprite_renderer.enabled = false;
        }
    }

    public void Reset()
    {
        dirt_sprite_renderer.enabled = true;
        is_clean = false;
        dirt_level = 0;
        dist_cleaned = 0f;
    }
}
