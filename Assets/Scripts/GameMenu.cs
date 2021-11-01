using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{

    public static int score { get; set; }

    private SaveGameManager saveManager;

    private Text scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = gameObject.GetComponent<SaveGameManager>();
        scoreTxt = GameObject.Find("HighScoreText").GetComponent<Text>();

        saveManager.LoadScore();

        scoreTxt.text = score.ToString();
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
