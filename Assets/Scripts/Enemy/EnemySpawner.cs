using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Dragon dragon;
    GameObject asteroid;
    float timer;

    public float randomTimerMin = 2;
    public float randomTimerMax = 5;

    public int minSpawn = 1;
    public int maxSpawn = 5;

    public float yOffset;


    // Start is called before the first frame update
    public void Start()
    {
        asteroid = GameAssets.instance.asteroid;
        dragon = FindObjectOfType<Dragon>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            for (int i = 0; i < Random.Range(minSpawn, maxSpawn); i++)
            {
                float spawnLocation = Random.Range(transform.position.x - 50f, transform.position.x + 50);

                float rotation = Random.Range(145, 190);
                GameObject new_bullet = Instantiate(asteroid, new Vector3(spawnLocation, transform.position.y, 0), Quaternion.Euler(0, 0, rotation));
            }

            timer = Random.Range(randomTimerMin, randomTimerMax);
        }


        Vector3 pos = dragon.transform.position + new Vector3(0, yOffset, 0);
        transform.position = pos;

    }
}
