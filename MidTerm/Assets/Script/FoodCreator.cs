using Unity.Mathematics;
using UnityEngine;


public class FoodCreator : MonoBehaviour
{

    public GameObject food;
    public bool isTrashCreator = false;
    public bool facingLeft = false;

    public float force = 5f;
   // public static FoodCreator instance;

void Start()
{
        InvokeRepeating("CreateFood", 3, .2f);
        
}

//insideunnitysphere
    void CreateFood()
    {
        GameObject newFood = Instantiate(food, transform.position, quaternion.identity);
        Rigidbody rb = newFood.GetComponent<Rigidbody>();
        rb.AddForce(force * transform.right, ForceMode.Impulse);
        if (isTrashCreator == true)
        {
            newFood.GetComponent<ObjectScript>().SetTrash();
         
        }
        else
        {
            newFood.GetComponent<ObjectScript>().SetFood();
        }
        
    }
    
}
