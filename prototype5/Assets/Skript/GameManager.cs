using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    public GameObject[] targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;

    private AudioSource audio;
    public Slider slider;
    public Button restartButton;
    public GameObject startMenu;

    public int lives;
    private int score;
    private float spawnRate = 1f;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("value");
        audio = GetComponent<AudioSource>();
    }
    
    public void StartGame(float dificult)
    {
        audio.Play();
        spawnRate /= dificult;
        startMenu.SetActive(false);
        isGameOver = false;
        StartCoroutine(SpawnTargets());
        score = 0;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }
    // спавн целей с интервалом 
    IEnumerator SpawnTargets()
    {
        while (!isGameOver)
        {
           yield return new  WaitForSeconds(spawnRate);
            int indexTarget = Random.Range(0,4);
            Instantiate(targets[indexTarget]);
        }
    }
    // вычитание хп
    public void SubtractingLives()
    {
        lives= lives - 1;
        if (lives <= 0) {
            GameOver();
            livesText.text = "Lives:0";
        }
        else {
            livesText.text = "Lives:" + lives;
        }
    }

    public void GameOver(){
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameOver = true;
    }
   // обновление счета 
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text ="Score: "+ score;
    }
    public void RestarGame(){
        PlayerPrefs.SetFloat("value",slider.value);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
