using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Main_Menu : MonoBehaviour
{
    public int Game1;
    public int Menu;

    private float score;
    private float hscore;

    ///private float savedscore;

    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI CScore;
    public TextMeshProUGUI MHighScore;

    void Start()
    {
       
    }

    void Update()
    {
        if (MHighScore != null)
        {
            hscore = GameManager.instance.HighScore();
            MHighScore.text = hscore.ToString();

            ///savedscore = PlayerPrefs.GetFloat("Highscore");
            ///MHighScore.text = savedscore.ToString();
        }

        if (HighScore != null)
        {
            hscore = GameManager.instance.HighScore();
            HighScore.text = hscore.ToString();

            ///savedscore = PlayerPrefs.GetFloat("Highscore");
            ///HighScore.text = savedscore.ToString();
        }

        if (CScore != null)
        {
            score = GameManager.instance.FinalScore();
            CScore.text = score.ToString();
        }

    }

    //Restart Button---------------------
    public void Restart()
    {
        GameManager.instance.cscore = 0f;
        SceneManager.LoadScene(Game1);
    }

    //Return to Main Menu Button---------
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(Menu);
    }

    //Start Game Button------------------
    public void StartGame()
    {
        GameManager.instance.cscore = 0f;
        SceneManager.LoadScene(Game1);
    }
  
    //Quit Game Button------------------
    public void QuitGame()
    {
        Application.Quit();
    }

    ///Save Score Button-----NOT DETECTING PlayerPrefs Defenitions--------

    ///public void SaveScore()
    ///{
    ///    PlayerPrefs.SetFloat("Highscore", hscore);
    ///}
}
