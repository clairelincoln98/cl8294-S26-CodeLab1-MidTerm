using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class GameManager : MonoBehaviour
{
    private const string DIR_RESOURCES = "/Resources/HighScore/";
    const string FILE_SCORES = DIR_RESOURCES + "highScore.txt";
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private const string KeyScore = "Score";
    private const string KeyHighScore = "High Score";

    private int score;

    public float time = 15f;

    public int Score
    {
        set //gets called whenever Score is set
        {
           
            print("Score:" + score);
            score = value; //sets the var "score" to the value of Score
            //Replaced PlayerPrefs with File IO
            PlayerPrefs.SetInt(KeyScore, score); //Saving the score to player prefs so it can be retrieved later (even after closing the game)
            
            
            if (score > HighScore) //int var score > the property HighScore
            {
                HighScore = score;
                print("High Score" + HighScore);
            }
        }
        get
        {
            score = PlayerPrefs.GetInt(KeyScore, 0); //Retrieving the score from player prefs
            
            
            return score;  //return the value of the "score" var
        }
    }
    
    private int highScore;

    public int HighScore  
    {
        get
        {
           //create a path 
            string fullFilePath = Application.dataPath + FILE_SCORES;

            //if there is no file
            if (!File.Exists(fullFilePath))
            {
                highScore = 1; //default high score is 1
            }
            else //otherwise
            {
                //get the contents out of the highScore file
                string fileContents = File.ReadAllText(fullFilePath);
                
                //turn the string version of those contents into an int
                highScore = int.Parse(fileContents);
            }

            return highScore;
        }

        set
        {
            //Debug.Log("Got High Score!!! : " + value);
            highScore = value;
           
            string fileContents = highScore + ""; //turn the score into a string we can put in a file
            
            string fullFilePath = Application.dataPath + FILE_SCORES;
            
            Debug.Log(fullFilePath);

            if (!File.Exists(fullFilePath))  //if we haven't saved already
            {
                //create the folder to save
                Directory.CreateDirectory(Application.dataPath + DIR_RESOURCES);
            }
            
            //Save the fileContents (highScore string) to the file "highScore.txt"
            File.WriteAllText(fullFilePath, fileContents);
        }
    }
    
    
    //set current level to 0
    public int currentLevel = 0;

    // make GameManager a singleton that is persistant between levels
    public static GameManager instance;

    // set up textmesh pro variables to be assigned in the inspector
    public TMP_Text scoreText;
    string defaultScoreText = "Score: <score> High Score: <high>";
   
    public TMP_Text timeText;
    string defaultTimeText = "Time: <time>";
    
    void Start()
    {
        //set score to 0 initially
        Score = 0;
        
       //check if there is a GameManager existings
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
    
    void Update() 
    
    {
        time -= Time.deltaTime;
        //create a string for default text that will automatically display
        string updatedScoreText = defaultScoreText;

        // Replace string using new values
        updatedScoreText = updatedScoreText.Replace("<score>", Score + ""); 
        updatedScoreText = updatedScoreText.Replace("<high>", HighScore + "");

        //repeat steps for score text
        string updatedTimeText = defaultTimeText;
        updatedTimeText = updatedTimeText.Replace("<time>", time + "");
        
        //update UI
        if (scoreText != null)
        {
            scoreText.text = updatedScoreText;
        }

        if (timeText != null)
        {
            timeText.text = updatedTimeText;
        }
        
        //check if the time has run out (when it reaches 0)
        if (time <= 0)
        {
            
            Debug.Log("Time is 0");
            //add 1 to the currentLevel variable
            currentLevel++;
            // Load the scene with the variable
            SceneManager.LoadScene(currentLevel);
            DraggableCreator.instance.objectCount = 0;
            DraggableCreator2.instance.objectCount = 0;
            time = 15f;
            
        }
        
        
    }
    
    

}
