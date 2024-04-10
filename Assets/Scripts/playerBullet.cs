using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour

{
    public static int score = 10;
    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            EnemySystem enemy = other.gameObject.transform.parent.gameObject.GetComponentInChildren<EnemySystem>();
            if (enemy)
            {
                enemy.TakeDamage(1);
            }
            Destroy(gameObject);
            score +=10;
        }
    }

    void onGUI() {
        GUI.Label(new Rect(100, 0, 400, 400), "Score: " + score);
    }
}
