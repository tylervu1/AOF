using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [Header("types of enemies")]
    public GameObject banana;
    public GameObject lemon;
    public GameObject melon;
    public GameObject carrot;

    [Header("For instantiating enemies")]
    public GameObject player;
    public Transform target;
    public GameControl game;

    [Header("Spawning control")]
    public float xPoz;
    public float yPoz;
    [SerializeField] float currTime, maxTime;
    public static int enemyCount = 0;
    public int numEnemiesToSpawn;
    public GameObject[] possibleEnemies;
    private List<GameObject> activeEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        maxTime = 1.5f;
        currTime = maxTime/2;
        possibleEnemies = new GameObject[] {banana, lemon, melon, carrot};
        // maxEnemy = game.GetMaxEnemies();
    }

    // Update is called once per frame
    void Update()
    {   
        // Debug.Log($"{enemyCount}, {numEnemiesToSpawn}");
        if (enemyCount == 0 && numEnemiesToSpawn == 0) {
            game.NextLevel();
        }

        if (numEnemiesToSpawn > 0)
        {
            SpawnEnemy(possibleEnemies, game.currLevel.xPoz1, game.currLevel.xPoz2, game.currLevel.yPoz1, game.currLevel.yPoz2);
        }
    }

    private void SpawnEnemy(GameObject[] possibleEnemies, float xpoz1, float xpoz2, float ypoz1, float ypoz2) {
        currTime -= Time.deltaTime;
        if (currTime >0) return;
        // Debug.Log($"Possible Enemies Length {possibleEnemies[0]}");
        numEnemiesToSpawn -=1;
        enemyCount += 1;

        Debug.Log($"spawnign enemy, {numEnemiesToSpawn} left, {enemyCount} enemeis left on the field");
        currTime = maxTime;

        xPoz = Random.Range(xpoz1, xpoz2);
        yPoz = Random.Range(ypoz1, ypoz2);

        // Choosing the next enemey
        var random = new System.Random();
        int ind = random.Next(possibleEnemies.Length);
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
            Debug.Log($"Removed Enemey. Enemies left {activeEnemies.Count}");
            enemyCount -=1;
        }
    }
}



