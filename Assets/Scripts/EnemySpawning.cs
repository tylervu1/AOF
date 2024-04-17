using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject banana;
    public GameObject lemon;
    public GameObject melon;
    public GameObject carrot;

    [Header("For instantiating enemies")]
    public GameObject player;
    public Transform target;

    [Header("Spawning values")]
    [SerializeField] static int level = 1;
    public float xPoz;
    public float yPoz;
    [SerializeField] float currTime, maxTime;


    public static int enemyCount = 0;
    [SerializeField] GameObject[] enemyList;
    private EnemySystem enemyScript;


    // Start is called before the first frame update
    void Start()
    {
        maxTime = 5f;
        enemyList = new GameObject[] {banana, lemon, melon, carrot};
    }

    // Update is called once per frame
    void Update()
    {
        switch (level)
        {
            case 0: // tutorial
                Debug.Log("Tutorial");
                break;

            case 1:
                Debug.Log("Starting level 1"); 
                //x from -244 to -87; y from 34 to -218 
                SpawnEnemy(enemyList, -15, -25, -15, -20);
                break;

        }
        // if (level > 0) {
        // }
    }

    void SpawnEnemy(GameObject[] possibleEnemies, float xpoz1, float xpoz2, float ypoz1, float ypoz2) {
        currTime -= Time.deltaTime;
        if (currTime >0) return;
        currTime = maxTime;

        xPoz = Random.Range(xpoz1, xpoz2);
        yPoz = Random.Range(ypoz1, ypoz2);
        enemyCount += 1;

        GameObject enemy = Instantiate(possibleEnemies[0], new Vector3(xPoz, 5, yPoz), Quaternion.identity);
        enemyScript = enemy.GetComponent<EnemySystem>();
        enemyScript.target= target;
        enemyScript.player = player;

        Debug.Log($"spawned an enemy at position {xPoz}, {yPoz}. Current enemy count: {enemyCount}");
    }
}
