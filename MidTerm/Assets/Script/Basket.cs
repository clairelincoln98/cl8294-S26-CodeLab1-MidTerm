using UnityEngine;

public class Basket : MonoBehaviour
{
    public static Basket instance; //make this a singleton so it shows up in the same place each level


    void Start()
    {
        if (instance == null)
        {
            // Don't destroy if there is no gamemanager in scene

            DontDestroyOnLoad(gameObject);
            instance = this;
            
        }
        else
        {
            // destroy the previous gamemanager if there is two present 
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        print(other);
        print(other.gameObject);
        if (other.gameObject.tag == "food")
        {
            //Debug.Log("collision working");
            GameManager.instance.Score = GameManager.instance.Score + 1;
        }
        
        if (other.gameObject.tag == "trash")
        {
            Debug.Log("trash working");
            GameManager.instance.Score--;
        }
        
        // if (other.gameObject.GetComponent<ObjectScript>()?.isTrash == true) //this was a solution when I thought the tags were causing issues
        // {
        //     Debug.Log("trash working");
        //     GameManager.instance.Score--;
        // }
    }
}
