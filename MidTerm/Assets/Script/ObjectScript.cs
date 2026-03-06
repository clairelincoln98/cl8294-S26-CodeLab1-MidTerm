using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{

    public bool isTrash = false;

    public GameObject trashChild;
    public GameObject foodChild;
    public Vector3 initialPosition;
    public Rigidbody rb;
    public float force = 1;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        // FoodCreator foodCreatorScript = FoodCreator.
        // if (FoodCreator.facingLeft == true)
        // { 
        //     Debug.Log("is facing left");
        //     rb. AddForce(force * Vector3.left);
        // }
        //
        // else if (FoodCreator.facingLeft == false)
        // {
        //     rb. AddForce(force * Vector3.right);
        // }
        
        
    }

    // Update is called once per frame
   public void SetTrash()
    {
        //set object to a state of being trash
        isTrash = true;
       // print("SetTrash");
        trashChild.SetActive(true);
        foodChild.SetActive(false);
        this.gameObject.tag = "trash";
        
    }

    public void SetFood()
    {
        //set object to a state of being food
        isTrash = false;
        //print("SetFood");
        foodChild.SetActive(true); //setting the corresponding child as active
        trashChild.SetActive(false); //setting the corresponding child as active
        this.gameObject.tag = "food";
    }

    public void Update()
    {
        
        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }

        float colliderRadius = gameObject.GetComponent<SphereCollider>().radius; //allows the ball to 'collide' even if its physics layer cant detect each other
        LayerMask collideLayer = LayerMask.GetMask("collidelayer");
        Collider[] foundCollisions = Physics.OverlapSphere(transform.position, colliderRadius, collideLayer);
        
        foreach (Collider col in foundCollisions)
        {
            //Debug.Log(col.gameObject.name);
            if (col.gameObject != this.gameObject && col.gameObject.tag == "trash")
            {
                //Debug.Log("Found trash");
                SetTrash();
            }
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        
        //if I am food and I am touching something that is not food and also trash, turn me into trash
        if (isTrash == false && collision.gameObject.tag == "trash")
        {
            //Debug.Log("Objects are touching");
            SetTrash();
        }
    }
}
