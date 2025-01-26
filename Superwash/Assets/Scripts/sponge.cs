using UnityEngine;

public class sponge : MonoBehaviour
{
    [SerializeField]
    float detergent_level = 0f;
    [SerializeField]
    float detergent_max = 300f;
    [SerializeField]
    float drop_amount = 100f;

    public float distance_moved_this_frame = 0f;

    public bool sponge_on_plate = false;
    public GameObject plate_obj;
    public WashableObject plate_script;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (sponge_on_plate && detergent_level > 0f)
        {
            plate_script.clean(distance_moved_this_frame);
            detergent_level -= distance_moved_this_frame;
            if (detergent_level < 0f) detergent_level = 0f;
        }
    }

    public void add_drop()
    {
        detergent_level += drop_amount;
        if (detergent_level > detergent_max)
            detergent_level = detergent_max;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("plate"))
        {
            sponge_on_plate = true;
            plate_obj = collision.gameObject;
            plate_script = plate_obj.GetComponent<WashableObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("plate"))
        {
            sponge_on_plate = false;
        }
    }
}
