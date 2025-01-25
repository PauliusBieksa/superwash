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
        if (drop.activeSelf)
            return;

        // TODO: add animation here

        drop.SetActive(true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(drop.transform.position.x - 1f, drop.transform.position.y - drop_distance, 1), new Vector3(drop.transform.position.x + 1f, drop.transform.position.y - drop_distance, 1));
    }
}
