using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoseCollider : MonoBehaviour {

    public int lives = 3;
    public Text text;
    private Paddle paddle;
    private Vector3 paddleBallVector;
    private LevelManager levelManager;

    void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
	void OnTriggerEnter2D(Collider2D trigger)
    {
        lives--;
        text.text = lives.ToString();
        Debug.Log(lives);
        if(lives <= 0)
        {
            Debug.Log("Lost");
            lives = 3;
            levelManager.LoadLevel("lose");
        } else
        {
            levelManager.ResetBall();
        }
        
    }

}
