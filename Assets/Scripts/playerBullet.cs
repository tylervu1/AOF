using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            Debug.Log("hit enemey");
            EnemySystem enemy = other.gameObject.transform.parent.gameObject.GetComponentInChildren<EnemySystem>();
            if (enemy) 
            {
                enemy.TakeDamage(1);
            }
            if (gameObject){    
                Destroy(gameObject);
            }
        } else if (LayerMask.LayerToName(other.gameObject.layer) == "Ground") {
            Debug.Log("hit Ground");
        }
    }

}
