using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameSession : MonoBehaviour
{
    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1;
    [SerializeField] int pointsPerBlock = 5;
    [SerializeField] int currrentScore = 0;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] bool isAutoplayEnabled;
    
    private void Awake()
    {
        int noOfGameStatus = FindObjectsOfType<GameSession>().Length;
        if (noOfGameStatus > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void Start()
    {
        currrentScore = 0;
        score.text = currrentScore.ToString();
    }
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    public void AddToScore()
    {
        currrentScore += pointsPerBlock;
        score.text = currrentScore.ToString();
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoplayEnabled;
    }
    
    public int GetCurrentScore()
    {
        return currrentScore;
    }
}