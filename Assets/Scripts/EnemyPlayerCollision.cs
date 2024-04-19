using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerCollision : MonoBehaviour
{
    public GameObject Enemy;
    public int DamageOnHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Hit player");
        if (other.gameObject.tag == "Player") {
            PlayerMovement player = other.gameObject.transform.parent.gameObject.GetComponentInChildren<PlayerMovement>();
            if (player)
            {
                player.TakeDamage(3);
            }
            Destroy(Enemy.gameObject);
        }
    }
}
