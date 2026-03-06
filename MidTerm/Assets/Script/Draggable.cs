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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
   
    void Start()
    {
        
        rigidBody = GetComponent<Rigidbody>();
       
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
    
    
}


