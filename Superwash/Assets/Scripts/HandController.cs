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
    GameObject sponge;

    private Vector3 move_dir = Vector3.zero;
    private bool is_hand_closed = false;
    public bool colliding_with_sponge;
 
    public bool holding_sponge;

    Rigidbody2D rig;
    SpriteRenderer sprite_renderer;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        sprite_renderer = GetComponent<SpriteRenderer>();
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

        if (is_hand_closed && colliding_with_sponge)
            holding_sponge = true;
        else
            holding_sponge = false;

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
            sponge.transform.position = new_pos;
        }

        Vector3 facing = (new Vector3(center_line, angle_coeficient, 0)) - new_pos;
        facing.Normalize();
        if (new_pos.x > center_line)
            transform.rotation = Quaternion.Euler(0, 0, -Vector3.Angle(facing, Vector3.up));
        else
            transform.rotation = Quaternion.Euler(0, 0, Vector3.Angle(facing, Vector3.up));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "sponge")
            colliding_with_sponge = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "sponge")
            colliding_with_sponge = false;
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
