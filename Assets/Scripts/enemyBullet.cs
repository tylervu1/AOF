using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public AudioClip shootClip;
    private AudioSource shootSource;
    public float hitPlayerPoint;

    // Start is called before the first frame update
    void Start()
    {
        shootSource = AddAudioSource(shootClip);
        shootSource.Play();
    }

    private AudioSource AddAudioSource(AudioClip clip)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.playOnAwake = false;
        return source;
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
            if (gameObject) {
                Destroy(gameObject);
            }
        }
    }
}
