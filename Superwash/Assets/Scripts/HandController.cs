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
  


    Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = new Vector3(0f, 0f, 0f);
        Vector3 new_pos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            dir += new Vector3(0f, 1f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += new Vector3(-1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += new Vector3(0f, -1f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += new Vector3(1f, 0f, 0f);
        }
        dir.Normalize();

        new_pos += dir * move_speed * Time.deltaTime;
        if (new_pos.x < edges[0]) new_pos.x = edges[0];
        if (new_pos.y > edges[1]) new_pos.y = edges[1];
        if (new_pos.x > edges[2]) new_pos.x = edges[2];
        if (new_pos.y < edges[3]) new_pos.y = edges[3];
        rig.MovePosition(new_pos);

        Vector3 facing = (new Vector3(center_line, angle_coeficient, 0)) - new_pos;
        facing.Normalize();
        Debug.Log(facing);
        if (new_pos.x > center_line)
            transform.rotation = Quaternion.Euler(0, 0, -Vector3.Angle(facing, Vector3.up));
        else
            transform.rotation = Quaternion.Euler(0, 0, Vector3.Angle(facing, Vector3.up));
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
