using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelValues : MonoBehaviour
{
    // Start is called before the first frame update
    public int level;
    public int xPoz1, xPoz2, yPoz1, yPoz2;
    public GameObject[] possibleEnemies;
    public int scoreThreshold;
    public float spawningRate;
    public int maxEnemy;
    void Start()
    {
        
    }

    public static LevelValues newLevel(int levelNum, int xPoz1, int xPoz2, int yPoz1, int yPoz2, int maxEnemy, int threshold) 
    {
        LevelValues level = new LevelValues();
        level.level = levelNum;
        level.xPoz1 = xPoz1;
        level.xPoz2 = xPoz2;
        level.yPoz1 = yPoz1;
        level.yPoz2 = yPoz2;
        level.maxEnemy = maxEnemy;
        level.scoreThreshold = threshold;
        return level;
    }

    public LevelValues nextLevel(int xPoz1, int xPoz2, int yPoz1, int yPoz2, int maxEnemy, int threshold)
    {
        LevelValues nextLevel = new LevelValues();
        nextLevel.level = level +1;
        nextLevel.xPoz1 = xPoz1;
        nextLevel.xPoz2 = xPoz2;
        nextLevel.yPoz1 = yPoz1;
        nextLevel.yPoz2 = yPoz2;
        nextLevel.maxEnemy = maxEnemy;
        nextLevel.scoreThreshold = threshold;
        return nextLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
