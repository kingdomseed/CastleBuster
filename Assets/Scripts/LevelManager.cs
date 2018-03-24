using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    private Ball ball;
    private Vector3 ballPos;
    private Vector2 ballVel;


    private void Start()
    {
        
        ball = GameObject.FindObjectOfType<Ball>();
        if(ball)
        {
            ballPos = ball.transform.position;
            ballVel = ball.GetComponent<Rigidbody2D>().velocity;
        }


    }
    public void LoadLevel (string level)
    {
        SceneManager.LoadScene(level);
        Brick.breakableCount = 0;
    }
    
    public void LoadNextLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Brick.breakableCount = 0;
    }

    public void BrickDestroyed()
    {
        if(Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }

    public void ResetBall()
    {
        Debug.Log("Called");
        ball.transform.position = ballPos;
        ball.GetComponent<Rigidbody2D>().velocity = ballVel;
        ball.SetStarted();
    }
}
