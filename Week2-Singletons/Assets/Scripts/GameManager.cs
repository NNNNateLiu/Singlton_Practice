using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //static variable means the value is the same for all the objects of this class type and the class itself
    public static GameManager instance; //this static var will hold the Singleton

    public int score = 0;

    public int targetScore = 3;

    public int currentLevel = 0;
    
    // if the player has cleared the level
    public bool isClear = false;

    public TextMesh text;  //TextMesh Component to tell you the time and the score
    
    // UI for choosing rewards phase
    public GameObject Rewards;
    private float showLevel;

    public bool isRoll = true;
    
    // prizeController parameters
    public int prizeCount = 1;
    public float prizeSizeModifier = 1;
    
    void Awake()
    {
        
        if (instance == null) //instance hasn't been set yet
        {
            DontDestroyOnLoad(gameObject);  //Dont Destroy this object when you load a new scene
            instance = this;  //set instance to this object
        }
        else  //if the instance is already set to an object
        {
            Destroy(gameObject); //destroy this new object, so there is only ever one
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        showLevel = currentLevel + 1;
        //update the text with the score and level
        text.text = "Level:" + showLevel + " Score: " + score + " Target: " + targetScore;
        
        if (score == targetScore)  //if the current score == the targetScore
        {
            //enter the choosing rewards phase
            isClear = true;
            Rewards.SetActive(true);
            text.gameObject.SetActive(false);
            if (isRoll)
            {
                global::Rewards.instance.ReRoll();
                isRoll = false;
                Debug.Log("Rolled");
            }
            
            //Debug.Log("level clear and choose the skill");
        }
    }
    
    // called when choose any button
    public void Proceed()
    {
        isRoll = true;
        currentLevel++; //increase the level number
        //Debug.Log("currentlevel:"+ GameManager.instance.currentLevel);
        targetScore += targetScore + targetScore/2; //update target score

        //exit the choosing rewards phase
        global::Rewards.instance.ReSet();
        text.gameObject.SetActive(true);
        Rewards.SetActive(false);
        isClear = false;
        SceneManager.LoadScene(instance.currentLevel); //go to the next level
        Debug.Log("proceed");
        Debug.Log("currentlevel:"+ GameManager.instance.currentLevel);
    }

    public void prizeSizeIncrease()
    {
        instance.prizeSizeModifier += .2f;
    }

    public void prizeNumIncrease()
    {
        instance.prizeCount += 1;
    }
    
    
}
