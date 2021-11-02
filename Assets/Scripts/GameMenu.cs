using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{ 
    private SaveGameManager saveManager;

    public static Text scoreTxt;
    public static Text timeTxt;

    public bool saved = false;

    private static GameObject instance;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = gameObject.GetComponent<SaveGameManager>();
        scoreTxt = GameObject.Find("HighScoreText").GetComponent<Text>();
        timeTxt = GameObject.Find("BestTimeText").GetComponent<Text>();
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = gameObject;
        }
        else DestroyImmediate(gameObject, true);

        if (saved)
        {
            saveManager.LoadScore();
            saveManager.LoadTime();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
