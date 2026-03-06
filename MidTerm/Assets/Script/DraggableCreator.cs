using Unity.VisualScripting;
using UnityEngine;

public class DraggableCreator : MonoBehaviour
{
    public GameObject prefab; //the object that this creator is creating
    private Vector3 currentMousePosition;
    public DraggableCreator creatorScript;
    public static DraggableCreator instance;
    public float objectCount = 0; //how many objects are in scene
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectCount = 0;
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    Vector3 GetMousePosition()
    {
        currentMousePosition = Input.mousePosition;
        currentMousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        currentMousePosition = Camera.main.ScreenToWorldPoint(currentMousePosition);
        
        return currentMousePosition;
    }

    // Update is called once per frame
  
    void OnMouseDown()
    {
        if (objectCount <= 5)
        {
            currentMousePosition = GetMousePosition();
            Quaternion rotation = Quaternion.Euler(0, 0, -30);
            Instantiate(prefab, currentMousePosition, rotation);
            objectCount++;
        }
    }

    void Update()
    {
        if (objectCount == 5)
        {
            Debug.Log(objectCount);
        }
    }
}
