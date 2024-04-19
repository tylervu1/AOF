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

    private static Hashtable levelStatistics = new Hashtable() {
        {1, new Hashtable() {{"Score", 15}, {"Max Enemies", 1}}},
        {2, new Hashtable() {{"Score", 30}, {"Max Enemies", 2}}},
        {3, new Hashtable() {{"Score", 45}, {"Max Enemies", 4}}},
        {4, new Hashtable() {{"Score", 60}, {"Max Enemies", 6}}},
        {5, new Hashtable() {{"Score", 100}, {"Max Enemies", 8}}},
        {6, new Hashtable() {{"Score", 200}, {"Max Enemies", 10}}},
    };
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
        level.maxEnemy = (int)(levelStatistics[levelNum] as Hashtable)["Max Enemies"];
        level.scoreThreshold = (int)(levelStatistics[levelNum] as Hashtable)["Score"];
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
        nextLevel.maxEnemy = (int) (levelStatistics[nextLevel.level] as Hashtable)["Max Enemies"];
        nextLevel.scoreThreshold = (int)(levelStatistics[nextLevel.level] as Hashtable)["Score"];
        return nextLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
