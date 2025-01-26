using UnityEngine;

public class Taps : MonoBehaviour
{
    private float timer = 0f;

    [SerializeField]
    float spin_duration = 1f;
    [SerializeField]
    Transform left_tap;
    [SerializeField]
    Transform right_tap;
    [SerializeField]
    GameObject water_obj;

    private bool open = false;
    private bool opening = false;
    private bool closed = true;
    private bool closing = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            timer += Time.deltaTime;
            if (timer > spin_duration) timer = spin_duration;
            left_tap.rotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(0f, 359f, timer / spin_duration));
            right_tap.rotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(0f, 359f, timer / spin_duration));
            if (timer == spin_duration)
            {
                opening = false;
                open = true;
                water_obj.SetActive(true);
            }
        }
        else if (closing)
        {
            timer += Time.deltaTime;
            if (timer > spin_duration) timer = spin_duration;
            left_tap.rotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(359f, 0f, timer / spin_duration));
            right_tap.rotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(359f, 0f, timer / spin_duration));
            if (timer == spin_duration)
            {
                closing = false;
                closed = true;
                water_obj.SetActive(false);
            }
        }
    }

    public void spin()
    {
        if (opening || closing)
            return;
        timer = 0f;
        if (open)
        {
            closing = true;
            open = false;
        }
        if (closed)
        {
            opening = true;
            closed = false;
        }
    }
}
