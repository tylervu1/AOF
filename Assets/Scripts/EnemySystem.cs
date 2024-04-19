using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    [Header("General")]
    public GameObject player;
    public Rigidbody rb;
    public Transform enemy;
    public Transform target;
    public GameControl game;


    [Header("Movement")]
    bool lookat = false;
    public float speed_out_of_range = 1f;
    public float speed_in_range = 0.5f;

    [Header("Health")]
    [SerializeField] float health, max_health = 5f; 
    [SerializeField] FloatingHealthBar healthBar;
    // Update is called once per frame
    
    [Header("Shooting")]
    public float bullet_speed;
    [SerializeField] private float timer = 2;
    [SerializeField] private float bulletTime;
    public GameObject bullet;
    public Transform spawnPoint;
    public int hitByBulletPoint;
    public int killedPoint;

    void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        health = max_health;
        bulletTime = timer;
    }
    void Update()
    {
        if (PlayerDetectionBig.found) {
            lookat = true;
        } 

        if (lookat) {
            Vector3 targetPosition = new Vector3(   target.transform.position.x,
                                                    enemy.transform.position.y,
                                                    target.transform.position.z);
            enemy.transform.LookAt(targetPosition);

            //if (!PlayerDetectionSmall.found) {
                if (PlayerDetectionBig.found) {
                    Vector3 pos = Vector3.MoveTowards(enemy.position, target.position, speed_in_range * Time.deltaTime);
                    rb.MovePosition(pos);
                } else {
                    Vector3 pos = Vector3.MoveTowards(enemy.position, target.position, speed_out_of_range * Time.deltaTime);
                    rb.MovePosition(pos);
                }

            ShootAtPlayer();
        }
    }

    void ShootAtPlayer() 
    {
        bulletTime -= Time.deltaTime;
        if (bulletTime > 0) return;
        bulletTime = timer;
        GameObject bulletObj = Instantiate(bullet, spawnPoint.transform.position, enemy.transform.rotation) as GameObject;
        Rigidbody bullet1 = bulletObj.GetComponent<Rigidbody>();
        bullet1.AddForce(bullet1.transform.forward * 100*bullet_speed);

        Destroy(bulletObj, 3f);
    }

    public void TakeDamage(float damage) 
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, max_health);
        if (health <= 0)
        {
            Destroy(gameObject);
            EnemySpawning.enemyCount -=1;
            game.AddScore(killedPoint);
        } else  {
            game.AddScore(hitByBulletPoint);
        }
    }
}
