using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 currentMousePosition;
    public float offSet = 1;
    public bool hasBeenClicked = false;
    public bool isInPlace = false;

    public Rigidbody rigidBody;
    private string filePath = "/Resources/DraggableObject/";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
   
    void Start()
    {
        
        rigidBody = GetComponent<Rigidbody>();
       filePath = Application.dataPath + filePath;
        string fileContents = File.ReadAllText(filePath + name + ".json");
        
        Debug.Log(fileContents);
        
        Vector3 savePosition = JsonUtility.FromJson<Vector3>(fileContents);
        transform.position = savePosition;
    }

    // Update is called once per frame
    void Update()
    {
        currentMousePosition = GetMousePosition();
        if (hasBeenClicked == false)
        {
            rigidBody.MovePosition(currentMousePosition);
        }
        
        if (hasBeenClicked == true)
        {
            isInPlace = true;
        }
    }

    void OnMouseDown()
    {
        hasBeenClicked = true;
        rigidBody.MovePosition(currentMousePosition);
        if (isInPlace == true)
        {
            Destroy(this.gameObject);
            DraggableCreator.instance.objectCount--;
        }
        
    }

    // void OnMouseDrag()
    // {
    //     currentMousePosition = GetMousePosition();
    // }
    Vector3 GetMousePosition()
    {
        currentMousePosition = Input.mousePosition;
        currentMousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        currentMousePosition = Camera.main.ScreenToWorldPoint(currentMousePosition);
        currentMousePosition.z = 0;
        
        return currentMousePosition;
    }

    void OnApplicationQuit()
    {
        string jsonPosition = JsonUtility.ToJson(transform.position, true);
        
        Debug.Log(jsonPosition);
        
        File.WriteAllText(filePath + name + ".json", jsonPosition);
    }

    
}


