using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //singleton
    public static GameManager instance;
   

    public float hscore;
    public float cscore;

    private float Timer = 60f;
    private float midTimer = 30f;
    private float endTimer = 0f;


    //to call -> GameManager.instance.------();

    // to call singleton's creation--------------------
    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        cscore = 0f;

        endTimer = Timer;
    }

    //Singleton Creation-------------------------------
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Update Current Score-----------------------------
    public float CurrentScore(float score)
    {
        cscore = cscore + score;
        return cscore;
    }

    //Send Current Score------------------------------
    public float FinalScore()
    {
        return cscore;
    }

    //Update and Send Highscore-----------------------
    public float HighScore()
    {
        if (cscore > hscore)
        {
            hscore = cscore;
            return hscore;
        }
        else if (hscore > cscore)
        {
            return hscore;
        }

        return hscore;
    }

    //Level Changes after X Time--------------------
    public void LevelTimer()
    {
        Timer -= Time.deltaTime;
        if (Timer <= midTimer && SceneManager.GetActiveScene().name == "Game1")
        {
            SceneManager.LoadScene("Game2");

        }
        else if (Timer <= 0 && SceneManager.GetActiveScene().name == "Game2")
        {
            SceneManager.LoadScene("EndScore");
            Timer = 60f;
        }
    }

    public float GetBarFill()
    {
        return Timer / endTimer;
    }

    //Check if object needs to be destroyed or not in transition;
    public void CheckStage(GameObject obj)
    {
         if (SceneManager.GetActiveScene().name == "Game1")
        {
            DontDestroyOnLoad(obj);
        }
        else if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name =="EndScore")
        {
            Destroy(obj);
        }
    }
}
