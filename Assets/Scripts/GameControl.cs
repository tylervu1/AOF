using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControl : MonoBehaviour
{
    [Header("GUI")]
    public GUISkin skin;
    public TMP_Text ScoreText;
    public TMP_Text LevelText;
    public TMP_Text EndText;

    [Header("level up values")]
    public static int score = 0; 
    public EnemySpawning enemySpawning;
    private int[] ScoreThreshold = new int[] {15, 30, 45, 60, 100, 200};
    private int[] EnemyMax = new int[] {1, 2, 4, 6, 8, 10};


    public LevelValues currLevel;

    // Start is called before the first frame update
    void Start()
    {
        currLevel = LevelValues.newLevel(1, -15, -25, -15, -20, EnemyMax[1], ScoreThreshold[1]);
        Debug.Log(currLevel.level);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddScore(int n)
    {
        score += n;
        ScoreText.SetText($"Score: {score}");
        if (score >= ScoreThreshold[currLevel.level])
        {
            NextLevel();
        }
    }

    private void NextLevel() //how to make new level only appear for a few seconds
    {
        currLevel = currLevel.nextLevel(-15, -25, -15, -20, EnemyMax[currLevel.level], ScoreThreshold[currLevel.level]);
        LevelText.SetText($"Moving onto level {currLevel.level}!");
        Debug.Log($"New Level {currLevel.level}");
        LevelText.SetText("");
    }

    public int GetMaxEnemies()
    {
        return EnemyMax[currLevel.level];
    }

    public void EndGame() 
    {
        Time.timeScale= 0;
        EndText.SetText($"Game Over! \n Your score was {score}");
    }

    void OnGUI() {
    }
}


// Current Issues:
// Make it so that there are specific combination of fruit taloring to each level
// Make each fruit have a different score, speed, bullet_speed attached to it depending on its difficulty
// Do not manually instantiate the level threshold and the max enemy threshold
// Figure out the bounding box for enemy spawning
// Figure out how to either (1) freeze the game for 1 second when level-up; or (2) display the level-up text for only 1 second 
// Make the GUI prettier
// More damage when the enemy is in contact with the player
// Make the bullet shooting from the enemy shoot in the y direction of the target; Destroy the bullet if it hits the terrain
// Figure out a good scoring system/leveling system
// Make the bullet match that of the enemy
// Create the tutorial/instruction page (just up/down/right/left/space movement, left click to shoot and mouse to aim, avoid enemy shots, but kill them)
// If two bullets collide, destory them both (fruit ninja aspect)