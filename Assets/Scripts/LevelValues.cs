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

    public GameObject[] possibleEnemies;

    [Header("Level-Specific")]
    public int level = 0;
    public float xPoz1, xPoz2, yPoz1, yPoz2;
    public float spawningRate;
    public int totalEnemies;

    private static Hashtable regionLabel = new Hashtable() {
        {0, new int[]{1}},
        {1, new int[]{1}},
        {2, new int[]{2}},
        {3, new int[]{1,2}},
        {4, new int[]{1,2}},
        {5, new int[]{1,3}},
        {6, new int[]{3}},
        {7, new int[]{2,3}},
        {8, new int[]{1, 2, 3}},
        {9, new int[]{1, 2, 3}},
        {10, new int[]{4}},
        {12, new int[]{1, 2, 3, 4}}
    };
    private int maxRecordedLevel = 12;

    public float[,] possibleLocations;

    private static Hashtable regionSpawnValues = new Hashtable() {
        {1, new float[] {-30,-13,-18, -5}},
        {2, new float[] {-30, -12, 2, 20}},
        {3, new float[] {-15, 11, 16, 38}},
        {4, new float[] {22, 34, -26, -36}},
    };


    void Start()
    {
        
    }
    public static LevelValues startNewLevel()
    {
        LevelValues emptyLevel = new LevelValues();
        emptyLevel.level = -1;
        return emptyLevel;
    }

    public LevelValues nextLevel()
    {
        float[] vals;
        LevelValues nextLevel = new LevelValues();
        nextLevel.level = level +1;
        nextLevel.totalEnemies = (int)((30/(1+System.Math.Exp((double)(-3 *(nextLevel.level))/5+4))) + 2);
        int[] currRegions;
        if (regionLabel.ContainsKey(nextLevel.level)) {
            currRegions = (int[]) regionLabel[nextLevel.level];
        } else {
            currRegions = (int[]) regionLabel[maxRecordedLevel];
        }
        nextLevel.possibleLocations = new float[currRegions.Length,4];
        for (int i = 0; i < currRegions.Length; i++) {
            nextLevel.possibleLocations[i,0] = ((float[]) regionSpawnValues[currRegions[i]])[0];
            nextLevel.possibleLocations[i,1] = ((float[]) regionSpawnValues[currRegions[i]])[1];
            nextLevel.possibleLocations[i,2] = ((float[]) regionSpawnValues[currRegions[i]])[2];
            nextLevel.possibleLocations[i,3] = ((float[]) regionSpawnValues[currRegions[i]])[3];

        }
        return nextLevel;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
