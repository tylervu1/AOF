using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    bool lookat = false;
    public GameObject player;
    public Rigidbody rb;
    public Transform enemy;
    public Transform target;
    public float speed_out_of_range = 1f;
    public float speed_in_range = 0.5f;
    public float bullet_speed;
    // Update is called once per frame
    
    
    [SerializeField] private float timer = 2;
    private float bulletTime;
    public GameObject bullet;
    public Transform spawnPoint;
    
    void Update()
    {
        if (PlayerDetectionBig.found) {
            lookat = true;
        } 

        if (lookat) {
            Vector3 targetPosition = new Vector3(   player.transform.position.x,
                                                    transform.position.y,
                                                    player.transform.position.z);
            transform.LookAt(targetPosition);

            //if (!PlayerDetectionSmall.found) {
                if (PlayerDetectionBig.found) {
                    Vector3 pos = Vector3.MoveTowards(enemy.position, target.position, speed_in_range * Time.deltaTime);
                    rb.MovePosition(pos);
                } else {
                    Vector3 pos = Vector3.MoveTowards(enemy.position, target.position, speed_out_of_range * Time.deltaTime);
                    rb.MovePosition(pos);
                }
            //} else {
            //    rb.velocity = new Vector3(0, 0, 0);
            //}
            ShootAtPlayer();
        }

        void ShootAtPlayer() {
            bulletTime -= Time.deltaTime;
            if (bulletTime > 0) return;
            bulletTime = timer;
            GameObject bulletObj = Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
            Rigidbody bullet1 = bulletObj.GetComponent<Rigidbody>();
            bullet1.AddForce(bullet1.transform.forward * 100*bullet_speed);
            Destroy(bullet1, 1f);
        }

    }
}
