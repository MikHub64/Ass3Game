using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", PacStudentController.score);
        PlayerPrefs.Save();
    }

    public void SaveTime()
    {
        PlayerPrefs.SetFloat("Time", PacStudentController.time);
        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            int loadedScore = PlayerPrefs.GetInt("Score");
            GameMenu.scoreTxt.text = loadedScore.ToString();
        }
    }

    public void LoadTime()
    {
        if (PlayerPrefs.HasKey("Time"))
        {
            float loadedTime = PlayerPrefs.GetFloat("Time");
            GameMenu.timeTxt.text = timeFormat(loadedTime);
        }
    }

    public string timeFormat(float time)
    {
        int min = (int)time / 60;
        int sec = (int)time - 60 * min;
        int ms = (int)(1000 * (time - min * 60 - sec));
        return string.Format("{0:00}:{1:00}:{2:000}", min, sec, ms);
    }
}
