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
    public bool is_wet = false;
    public bool is_being_held = false;

    private float next_threshold = 0f;

    void Start()
    {
        if (dist_to_clean.Count > 0)
            next_threshold = dist_to_clean[0];
    }

    public void clean(float dist)
    {
        if (!is_wet || is_clean) return;
        dist_cleaned += dist;

        while (dist_cleaned >= next_threshold && dirt_level < dist_to_clean.Count - 1)
        {
            dirt_level++;
            dirt_sprite_renderer.sprite = dirt_sprites[dirt_level];

            next_threshold += dist_to_clean[dirt_level];
        }

        if (dist_cleaned >= next_threshold && dirt_level == dist_to_clean.Count - 1)
        {
            is_clean = true;
            FindFirstObjectByType<PlateStacking>().RemovePlateFromStack();
            dirt_sprite_renderer.enabled = false;
        }
    }

    public void Reset()
    {
        dirt_sprite_renderer.enabled = true;
        is_clean = false;
        dirt_level = 0;
        dist_cleaned = 0f;

        if (dist_to_clean.Count > 0)
            next_threshold = dist_to_clean[0];

        dirt_sprite_renderer.sprite = dirt_sprites[0];
    }
}
