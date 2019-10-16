using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finishText;
    public TextMeshProUGUI HealthBar;
    public TextMeshProUGUI AreaText;
    public Button lextLevle;

    public int food;
    public int area ;
    public int health;

    public bool isFinish = false;
    public bool isGameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        food = 0;
        scoreText.text = "Food : " + food;
        UpdateScore(0);

        area = 0;
        AreaText.text = "Area : " + area;

        health = 100;
        HealthBar.text = "Health : " + health;

    }

    // Update is called once per frame
    void Update()
    {
        if (isFinish)
        {
            finishText.gameObject.SetActive(true);
            lextLevle.gameObject.SetActive(true);
        }
        
    }

    public void UpdateScore(int lastScore)
    {
        food += lastScore;
        scoreText.text = "Food : " + food;
        if (food == 10)
            isFinish = true;
    }

    public void UpdateArea(int lastArea)
    {
        area += lastArea;
        AreaText.text = "Area : " + area;

        if (area == 30)
            isFinish = true;
    }

    public void Attacked(int lastHealth)
    {
        health -= lastHealth;
        HealthBar.text = "Health : " + health;

        if (health == 0)
            isGameOver = true;
    }

    public void goToNextLevel(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

}
