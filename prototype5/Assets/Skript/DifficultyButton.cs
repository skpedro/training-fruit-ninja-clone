using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    private Button mod;
    private GameManager gameManager;
    private GameManager target;

    public int lives;
    public float difficult;
    void Start()
    {
        
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        mod = GetComponent<Button>();
        mod.onClick.AddListener(SetDifficult);
    }

    void SetDifficult()
    {
        gameManager.lives = lives;
        gameManager.StartGame(difficult);
        Debug.Log(gameObject.name+" Was clicked");
    }
}
