using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip lootSound;

    DragonHeadCollision collision;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        collision = GetComponent<DragonHeadCollision>();

        collision.OnLootCollided += PlayLootSound;

    }

    void PlayLootSound()
    {
        audioSource.clip = lootSound;
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        audioSource.Play();
    }

}
