using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    /// No Longer in Use

    public TextMeshProUGUI Ptext;
    public TextMeshProUGUI hscoretext;
    private float score;
    private float highscore;


    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void Setup()
    {
            gameObject.SetActive(true);
            score = GameManager.instance.FinalScore();
            Ptext.text = score.ToString();
            highscore = GameManager.instance.HighScore();
            hscoretext.text = highscore.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
