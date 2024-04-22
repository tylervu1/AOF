using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [Header("types of enemies")]
    public static GameObject banana;
    public static GameObject lemon;
    public static GameObject melon;
    public static GameObject carrot;

    [Header("For instantiating enemies")]
    public GameObject player;
    public Transform target;
    public GameControl game;

    [Header("Spawning control")]
    public float[,] possibleLocations;
    // public float yPoz;
    [SerializeField] float currTime, maxTime;
    public static int enemyCount = 0;
    public int numEnemiesToSpawn;
    public GameObject[] possibleEnemies;
    private List<GameObject> activeEnemies = new List<GameObject>();
    public bool waves;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = 3f;
        currTime = maxTime/2;
        possibleEnemies = new GameObject[] {banana, lemon, melon, carrot};
        possibleLocations = new float[1,4] {{0, 0, 0, 0}};
    }

    // Update is called once per frame
    void Update()
    {   
        if (enemyCount == 0 && numEnemiesToSpawn == 0) {
            game.NextLevel();
        }

        if (numEnemiesToSpawn > 0)
        {
            SpawnEnemy(possibleEnemies);
        }
    }

    private void SpawnEnemy(GameObject[] possibleEnemies) {
        // Check if the enemy will spawn at this time
        currTime -= Time.deltaTime;
        if (currTime >0) return;
        numEnemiesToSpawn -=1;
        enemyCount += 1;

        Debug.Log($"spawnign enemy, {numEnemiesToSpawn} left, {enemyCount} enemeis left on the field");
        currTime = Random.Range(1, maxTime);

        //Choosing the location to spawn the enemy
        var randomLocation = new System.Random();
        int indRegion = randomLocation.Next(possibleLocations.GetLength(0));
        Debug.Log($"{indRegion}, {possibleLocations.GetLength(0)}");

        float xPoz = Random.Range(possibleLocations[indRegion,0], possibleLocations[indRegion,1]);
        float yPoz = Random.Range(possibleLocations[indRegion,2], possibleLocations[indRegion,3]);

        // Choosing the next enemey
        var random = new System.Random();
        int ind = random.Next(possibleEnemies.Length);

        //Spawning the enemy
        GameObject enemy = Instantiate(possibleEnemies[ind], new Vector3(xPoz, 5, yPoz), Quaternion.identity);
        EnemySystem enemyScript = enemy.GetComponent<EnemySystem>();
        enemyScript.target= target;
        enemyScript.player = player;
        enemyScript.game = game;

        Debug.Log($"spawned an enemy at position {xPoz}, {yPoz}. Current enemy count: {enemyCount}");
        activeEnemies.Add(enemy);
    }

    public void RemoveEnemy(GameObject enemy) {
        if (activeEnemies.Contains(enemy)) {
            activeEnemies.Remove(enemy);
            enemyCount -=1;
        }
    }
}



