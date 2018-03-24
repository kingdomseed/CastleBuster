using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleBallVector;
    private bool hasStarted = false;
    private AudioSource[] sounds;
    private AudioSource hit;
    private AudioSource crumble;
    private AudioSource launch;

    // Use this for initialization
    void Start ()
    {
        paddle = FindObjectOfType<Paddle>();
        paddleBallVector = this.transform.position - paddle.transform.position;
        sounds = GetComponents<AudioSource>();
        hit = sounds[0];
        crumble = sounds[1];
        launch = sounds[2];
    }
	
	// Update is called once per frame
	void Update () {

        StartGame();
        
	}

    public void StartGame()
    {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                launch.Play();
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
    }

    public bool SetStarted()
    {
        hasStarted = false;
        return hasStarted;
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted)
        {
            if (col.gameObject.tag == "Breakable")
            {
                crumble.Play();
                GetComponent<Rigidbody2D>().velocity += tweak;
            } else
            {
                hit.Play();
            }
            
        }
    }
}
