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
    private float speed_out_of_range = 1f;
    private float speed_in_range = 0.5f;
    // Update is called once per frame
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
        }
    }
}
