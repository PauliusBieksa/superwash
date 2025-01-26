using UnityEngine;

public class TakeAway : MonoBehaviour
{
    WashableObject plate_script;
    GameObject plate_obj;

    [SerializeField]
    float duration = 1f;
    [SerializeField]
    Transform hand_transform;

    float timer = 0f;
    bool animating = false;
    Vector3 start_pos;
    Vector3 pickup_pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start_pos = hand_transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (animating)
        {
            timer += Time.deltaTime;
            if (timer < duration / 2f)
            {
                hand_transform.position = Vector3.Lerp(start_pos, pickup_pos, timer / (duration / 2f));
            }
            else if (timer < duration)
            {
                hand_transform.position = Vector3.Lerp(pickup_pos, start_pos, (timer - (duration / 2f)) / (duration / 2f));
                plate_obj.transform.position = Vector3.Lerp(pickup_pos, start_pos, (timer - (duration / 2f)) / (duration / 2f));
            }
            if (timer >= duration) animating = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "plate")
        {
            plate_script = collision.GetComponent<WashableObject>();
            plate_obj = collision.gameObject;
            if (!plate_script.is_being_held && plate_script.is_clean)
            {
                plate_obj.GetComponent<CapsuleCollider2D>().enabled = false;
                animating = true;
                timer = 0;
                pickup_pos = plate_obj.transform.position;
            }
        }
    }
}
