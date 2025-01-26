using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField]
    float move_speed = 8f;

    [SerializeField]
    bool show_debug = true;
    [SerializeField][Tooltip("Literal xy positions for LEFT, TOP, RIGHT, BOTTOM movement borders")]
    float[] edges = {1f, 1f, 1f, 1f};
    [SerializeField]
    float center_line = 0f;
    [SerializeField]
    float angle_coeficient = -10f;

    [SerializeField]
    Sprite open_sprite;
    [SerializeField]
    Sprite closed_sprite;
    [SerializeField]
    GameObject sponge_obj;
    sponge sponge_script;
    [SerializeField]
    detergent detergent_script;
    [SerializeField]
    Taps taps_script;

    private Vector3 move_dir = Vector3.zero;
    private bool is_hand_closed = false;
    private bool colliding_with_sponge = false;
    private bool hand_on_detergent = false;
    private bool hand_on_taps = false;
    private bool hand_on_plate = false;

    public bool holding_sponge;
    public bool holding_plate;
    GameObject plate_obj;
    WashableObject plate_script;

    Rigidbody2D rig;
    SpriteRenderer sprite_renderer;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        sponge_script = sponge_obj.GetComponent<sponge>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Interact") > 0 && !is_hand_closed)
        {
            is_hand_closed = true;
            sprite_renderer.sprite = closed_sprite;
        }
        if (Input.GetAxisRaw("Interact") == 0 && is_hand_closed)
        {
            is_hand_closed = false;
            sprite_renderer.sprite = open_sprite;
        }

        if (is_hand_closed && colliding_with_sponge && !holding_plate)
            holding_sponge = true;
        else
            holding_sponge = false;

        if (is_hand_closed && hand_on_plate && !holding_sponge)
            holding_plate = true;
        else
            holding_plate = false;

        // movement
        move_dir = new Vector3(0f, 0f, 0f);
        Vector3 new_pos = transform.position;
        move_dir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        new_pos += move_dir * move_speed * Time.deltaTime;
        if (new_pos.x < edges[0]) new_pos.x = edges[0];
        if (new_pos.y > edges[1]) new_pos.y = edges[1];
        if (new_pos.x > edges[2]) new_pos.x = edges[2];
        if (new_pos.y < edges[3]) new_pos.y = edges[3];
        rig.MovePosition(new_pos);

        // moving the sponge
        if (holding_sponge)
        {
            sponge_obj.transform.position = new_pos;
            sponge_script.distance_moved_this_frame = (move_dir * move_speed).magnitude;
        }
        // moving the plate
        if (holding_plate)
        {
            plate_obj.transform.position = new_pos;
            plate_script.is_being_held = true;
        }
        else if (plate_script != null)
        {
            plate_script.is_being_held = false;
        }

        Vector3 facing = (new Vector3(center_line, angle_coeficient, 0)) - new_pos;
        facing.Normalize();
        if (new_pos.x > center_line)
            transform.rotation = Quaternion.Euler(0, 0, -Vector3.Angle(facing, Vector3.up));
        else
            transform.rotation = Quaternion.Euler(0, 0, Vector3.Angle(facing, Vector3.up));

        if (!holding_sponge && !holding_plate)
        {
            if (hand_on_detergent && Input.GetAxisRaw("Interact") > 0)
            {
                detergent_script.Squeeze();
            }
            if (hand_on_taps && Input.GetAxisRaw("Interact") > 0)
            {
                taps_script.spin();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "sponge")
            colliding_with_sponge = true;
        else if (collision.tag == "detergent")
            hand_on_detergent = true;
        else if (collision.tag == "taps")
            hand_on_taps = true;
        else if (collision.tag == "plate")
        {
            hand_on_plate = true;
            plate_obj = collision.gameObject;
            plate_script = plate_obj.GetComponent<WashableObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "sponge")
            colliding_with_sponge = false;
        else if (collision.tag == "detergent")
            hand_on_detergent = false;
        else if (collision.tag == "taps")
            hand_on_taps = false;
        else if (collision.tag == "plate")
            hand_on_plate = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (show_debug)
        {
            Vector3[] points = new Vector3[8];

            points[0] = new Vector3(edges[0], -20f, 1);
            points[1] = new Vector3(edges[0], 20f, 1);
            points[2] = new Vector3(-20f, edges[1], 1);
            points[3] = new Vector3(20f, edges[1], 1);
            points[4] = new Vector3(edges[2], -20f, 1);
            points[5] = new Vector3(edges[2], 20f, 1);
            points[6] = new Vector3(-20f, edges[3], 1);
            points[7] = new Vector3(20f, edges[3], 1);
            Gizmos.color = Color.red;
            Gizmos.DrawLineList(points);

            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(new Vector3(center_line, -20f, 1), new Vector3(center_line, 20f, 1));
        }
    }
}
