using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprite;
    public static int breakableCount = 0;
    public GameObject fire;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

 
    void Start ()
    {
        isBreakable = (this.tag == "Breakable");
        if(isBreakable)
        {
            breakableCount++;
        }
        timesHit = 0;
        levelManager = FindObjectOfType<LevelManager>();
	}
	
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprite.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            FireGo();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void FireGo ()
    {
        GameObject Fire = Instantiate (fire, transform.position, Quaternion.identity) as GameObject;
        
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprite[spriteIndex])
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
        } else
        {
            Debug.LogError("Missing a brick sprite?");
        }
    }

    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
