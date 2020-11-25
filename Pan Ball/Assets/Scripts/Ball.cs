using UnityEngine;
public class Ball : MonoBehaviour
{
    // config params
    [SerializeField ]Pan pan;
    [SerializeField] float velocityX = 3, velocityY = 10;

    // state variables
    Vector2 ballToPanDistance;
    bool hasLaunched=false;

    void Start()
    {
        ballToPanDistance = transform.position - pan.transform.position;
    }

    void Update()
    {
        if (!hasLaunched)
        {
            LockBallToPan();
            LaunchBallFromPan();
        }
    }

    private void LaunchBallFromPan()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasLaunched = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
        }
    }

    private void LockBallToPan()
    {
        Vector2 panPos = new Vector2(pan.transform.position.x, pan.transform.position.y);
        transform.position = panPos + ballToPanDistance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasLaunched)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}