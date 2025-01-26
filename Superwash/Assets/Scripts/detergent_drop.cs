using UnityEngine;

public class detergent_drop : MonoBehaviour
{
    [SerializeField]
    float drop_speed = 5f;
    [SerializeField]
    detergent detergent_script;
    [SerializeField]
    sponge sponge_script;

    float timer = 0f;
    Vector3 start_pos = Vector3.zero;
    float end_y = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start_pos = transform.position;
        end_y = start_pos.y - detergent_script.drop_distance;
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer < 1f)
        {
            transform.localScale = new Vector3(Mathf.Lerp(0.1f, 1f, timer), Mathf.Lerp(0.1f, 1f, timer), 1);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - drop_speed * Time.deltaTime, transform.position.z);
        }

        if (transform.position.y < end_y)
        {
            transform.position = start_pos;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "sponge")
        {
            sponge_script.add_drop();
            transform.position = start_pos;
            gameObject.SetActive(false);
        }
    }


    private void OnEnable()
    {
        timer = 0f;
    }
}
