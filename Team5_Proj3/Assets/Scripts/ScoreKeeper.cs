using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ScoreKeeper : MonoBehaviour
{
    public static int finalScore1;
    public static int finalScore2;
    private string currentScene;

    [SerializeField] TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void scoreKeeper(int points)
    {
        if(currentScene == "Level_1")
        {
            finalScore1 += points;
            scoreText.text = finalScore1.ToString();
        }
        else if(currentScene == "Level_2")
        {
            finalScore2 += points;
            scoreText.text = finalScore2.ToString();
        }
    }

}
