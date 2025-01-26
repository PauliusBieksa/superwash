using UnityEngine;

public class detergent : MonoBehaviour
{
    public float drop_distance = 2f;
    [SerializeField]
    GameObject drop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Squeeze()
    {
        var dropq = Instantiate(drop, new Vector3(7.288883f, 3.41f,0f), Quaternion.identity);
        dropq.SetActive(true);
        //if (drop.activeSelf)
        //    return;

        // TODO: add animation here

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(drop.transform.position.x - 1f, drop.transform.position.y - drop_distance, 1), new Vector3(drop.transform.position.x + 1f, drop.transform.position.y - drop_distance, 1));
    }
}
