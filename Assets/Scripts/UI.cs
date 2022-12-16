using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    Player myPlayer;
    public Image Timebar;
    [SerializeField] GameObject player;

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI Ptext;

    private float score = 0f;


    void Awake()
    {
        myPlayer = player.GetComponent<Player>();
    }

    void Update()
    {
        Timebar.fillAmount = GameManager.instance.GetBarFill();
        score = GameManager.instance.FinalScore();
        UpdateHighScore(score);

        GameManager.instance.CheckStage(gameObject);
    }

    //Current Score Counter-------------------------
    public void UpdateHighScore(float pts)
    {
        pointsText.text = "" + pts;
    }

}
