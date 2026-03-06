using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public static Background instance;
    void Start()
    {
        if (instance == null)
        {
            // Don't destroy if there is no background in scene

            DontDestroyOnLoad(gameObject);
            instance = this;
            
        }
        else
        {
            // destroy the previous background if there is two present 
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
