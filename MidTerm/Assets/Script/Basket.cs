using UnityEngine;

public class Basket : MonoBehaviour
{
    public static Basket instance; //make this a singleton so it shows up in the same place each level

    public float foodCount = 0;

    void Update()
    {
        Debug.Log(foodCount);
        if (foodCount >= 5) //for every 10 fresh eggs, add a point to Score
        {
            Debug.Log("foodcount" + foodCount);
            GameManager.instance.Score = GameManager.instance.Score + 1;
            foodCount = 0;
        }
        
    }
    
    void Start()
    {
        if (instance == null)
        {
            // Don't destroy if there is no Basket in scene

            DontDestroyOnLoad(gameObject);
            instance = this;
            
        }
        else
        {
            // destroy the previous Basket if there is two present 
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //print(other);
        //print(other.gameObject);
        if (other.gameObject.tag == "food")
        {
            foodCount += 1;
            // if (foodCount >= 10)
            // {
            //     GameManager.instance.Score = GameManager.instance.Score + 1;
            // }
            Debug.Log("collision working");
        }
        
        
        if (other.gameObject.tag == "trash")
        {
            foodCount -= 1; //for every rotten egg, minus a point from foodcount
            Debug.Log("trash working");
            //GameManager.instance.Score--; Removed this to make system more forgiving
        }
        
        // if (other.gameObject.GetComponent<ObjectScript>()?.isTrash == true) //this was a solution when I thought the tags were causing issues
        // {
        //     Debug.Log("trash working");
        //     GameManager.instance.Score--;
        // }
    }
}
