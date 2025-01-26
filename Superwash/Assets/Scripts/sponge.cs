using UnityEngine;

public class sponge : MonoBehaviour
{
    [SerializeField]
    float detergent_level = 0f;
    [SerializeField]
    float detergent_max = 300f;
    [SerializeField]
    float drop_amount = 100f;
    public float distance_washed = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void add_drop()
    {
        detergent_level += drop_amount;
        if (detergent_level > detergent_max)
            detergent_level = detergent_max;
    }
}
