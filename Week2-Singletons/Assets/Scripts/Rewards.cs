using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rewards : MonoBehaviour
{
    public List<GameObject> buttonsSet1;
    public List<GameObject> buttonsSet2;
    public List<GameObject> buttonsSet3;

    public List<Transform> buttonTransforms;

    public GameObject panel;
    
    public static Rewards instance;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) //instance hasn't been set yet
        {
            DontDestroyOnLoad(gameObject); //Dont Destroy this object when you load a new scene
            instance = this; //set instance to this object
        }
        else //if the instance is already set to an object
        {
            Destroy(gameObject); //destroy this new object, so there is only ever one
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    public void ReRoll()
    {
        //choose 1 out of 4 buttons
        buttonsSet1[Random.Range(0,buttonsSet1.Count)].SetActive(true);
        buttonsSet2[Random.Range(0,buttonsSet1.Count)].SetActive(true);
        buttonsSet3[Random.Range(0,buttonsSet1.Count)].SetActive(true);
        Debug.Log("ReRoll!");
    }

    public void ReSet()
    {
        // reset the choosing function for next call
        foreach (var button in buttonsSet1)
        {
            button.SetActive(false);
        }
        foreach (var button in buttonsSet2)
        {
            button.SetActive(false);
        }
        foreach (var button in buttonsSet3)
        {
            button.SetActive(false);
        }
    }
}
