using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    // config params
    [SerializeField] float screenWidth = 16f;
    [SerializeField] float minX = 0.543f, maxX = 20.643f;

    // cached reference
    Ball ball;
    GameSession gameSession;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        Vector2 panPos = new Vector2(transform.position.x, transform.position.y);
        panPos.x = Mathf.Clamp(CalculateXPos(), minX, maxX);
        transform.position = panPos;
    }

    private float CalculateXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidth;
        }
    }
}
