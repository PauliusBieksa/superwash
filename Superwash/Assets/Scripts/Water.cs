using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("SSS");
        if (collision.CompareTag("plate"))
        {
            Debug.Log("SSSsdfhbsdfb ");
            collision.GetComponent<WashableObject>().is_wet = true;
        }
    }
}
