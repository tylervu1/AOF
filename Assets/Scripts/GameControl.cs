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


    [Header("types of enemies")]
    public GameObject banana;
    public GameObject lemon;
    public GameObject melon;
    public GameObject carrot;
    public GameObject[][] enemyList;

    [Header("Game Stats")]
    public static int score = 0; 
    public EnemySpawning enemySpawning;

    public LevelValues currLevel;

    // Start is called before the first frame update
    void Start()
    {
        LevelValues.banana = banana;
        LevelValues.carrot = carrot;
        LevelValues.melon = melon;
        LevelValues.lemon = lemon;
        enemyList = new[] {
            new [] {banana},
            new [] {banana},
            new [] {carrot},
            new [] {banana, carrot},
            new [] {banana, carrot},
            new [] {lemon},
            new [] {banana, carrot, lemon},
            new [] {banana, carrot, lemon},
            new [] {banana, carrot, lemon},
            new [] {banana, carrot, lemon},
            new [] {melon},
            new [] {banana, carrot, lemon, melon},
            new [] {banana, carrot, lemon, melon}
        };

        currLevel = LevelValues.startNewLevel();
        NextLevel();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddScore(int n)
    {
        score += n;
        ScoreText.SetText($"Score: {score}");
    }

    public void NextLevel() //how to make new level only appear for a few seconds
    {
        Debug.Log($"Moving on to level {currLevel.level + 1}");
        currLevel = currLevel.nextLevel();
        if (currLevel.level < enemyList.Length) {
            currLevel.possibleEnemies = enemyList[currLevel.level];
        } else {
            currLevel.possibleEnemies = enemyList[^1];
        }

        LevelText.SetText($"Moving onto level {currLevel.level}!");
        LevelText.SetText("");
        enemySpawning.numEnemiesToSpawn = currLevel.totalEnemies;
        enemySpawning.possibleEnemies = currLevel.possibleEnemies;
        enemySpawning.possibleLocations = currLevel.possibleLocations;
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
// Figure out a good scoring system/leveling system
// Make each fruit have a different score, speed, bullet_speed attached to it depending on its difficulty
// Do not manually instantiate the level threshold and the max enemy threshold
// Figure out the bounding box for enemy spawning
// Figure out how to either (1) freeze the game for 1 second when level-up; or (2) display the level-up text for only 1 second 

// Make the GUI prettier
// Particles for damage (bullet hit, enemy exploding?)

// Make the bullet shooting from the enemy shoot in the y direction of the target; Destroy the bullet if it hits the terrain
// Make the bullet match that of the enemy
// Create the tutorial/instruction page (just up/down/right/left/space movement, left click to shoot and mouse to aim, avoid enemy shots, but kill them)
// If two bullets collide, destory them both (fruit ninja aspect)

