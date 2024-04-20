using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelValues : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("types of enemies")]
    public static GameObject banana;
    public static GameObject lemon;
    public static GameObject melon;
    public static GameObject carrot;

    // public GameObject[,] possibleEnemies = new GameObject[] [[banana], [banana], [carrot], [banana, carrot], [banana, carrot], [lemon], [banana, carrot, lemon], [banana, carrot, lemon], [banana, carrot, lemon], [banana, carrot, lemon], [banana, carrot, lemon, melon]];
    public GameObject[] possibleEnemies;

    [Header("Level-Specific")]
    public int level;
    public int xPoz1, xPoz2, yPoz1, yPoz2;
    public float spawningRate;
    public int totalEnemies;

    void Start()
    {
        
    }
    public static LevelValues newLevel(int levelNum, int xPoz1, int xPoz2, int yPoz1, int yPoz2) 
    {
        LevelValues level = new LevelValues();
        level.level = levelNum;
        level.xPoz1 = xPoz1;
        level.xPoz2 = xPoz2;
        level.yPoz1 = yPoz1;
        level.yPoz2 = yPoz2;
        level.totalEnemies = 1;
        return level;
    }

    public LevelValues nextLevel(int xPoz1, int xPoz2, int yPoz1, int yPoz2)
    {
        LevelValues nextLevel = new LevelValues();
        nextLevel.level = level +1;
        nextLevel.xPoz1 = xPoz1;
        nextLevel.xPoz2 = xPoz2;
        nextLevel.yPoz1 = yPoz1;
        nextLevel.yPoz2 = yPoz2;
        nextLevel.totalEnemies = (int)((30/(1+System.Math.Exp((double)(-3 *(nextLevel.level))/5+4))) + 2);
        // nextLevel.possibleEnemies = possibleEnemies;
        // if (nextLevel.level < enemyList.Length) {
        //     nextLevel.possibleEnemies = enemyList[nextLevel.level];
        // } else {
        //     nextLevel.possibleEnemies = enemyList[^1];
        // }
        return nextLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
