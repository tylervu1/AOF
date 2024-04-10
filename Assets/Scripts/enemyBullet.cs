using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            PlayerMovement player = other.gameObject.transform.parent.gameObject.GetComponentInChildren<PlayerMovement>();
            if (player)
            {
                player.TakeDamage(1);
            }
            // Destroy(gameObject);
        }
    }
}
