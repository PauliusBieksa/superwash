using System.Collections.Generic;
using UnityEngine;

public class PlateStacking : MonoBehaviour
{
    [Header("Plate Settings")]
    public GameObject platePrefab;
    private Transform stackArea;
    public int basePlates;  
    public float plateHeight = 0.2f;
   
    private int totalPlates;
    private Stack<GameObject> plateStack;

    private void Start()
    {
        stackArea = transform;
        plateStack = new Stack<GameObject>();
        InitializePlates();
    }

    private void InitializePlates()
    {
        for (int i = 0; i < basePlates; i++)
        {
            AddPlateToStack();
        }
    }

    private void AddPlateToStack()
    {
        GameObject newPlate = Instantiate(platePrefab, stackArea);
        Vector3 platePosition = stackArea.position + new Vector3(0, plateStack.Count * plateHeight, 0);
        totalPlates++;
        newPlate.transform.position = platePosition;
        plateStack.Push(newPlate);
    }

    public void RemovePlateFromStack()
    {
        if (plateStack.Count > 0)
        {
            GameObject plateToRemove = plateStack.Pop();
            totalPlates--;
            Destroy(plateToRemove);
        }
    }
}
