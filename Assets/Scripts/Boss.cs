using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private int health;
    private GameObject enemySpawner;
    private bool allowMinionsSpawn;

    private static GameObject[] minions;
    private static Vector2[] destinations;

    private void Start()
    {
        health = gameObject.GetComponent<Enemy>().health;
        enemySpawner = GameObject.Find("EnemySpawner");
        allowMinionsSpawn = true;

        destinations = new Vector2[4];
        destinations[0] = new Vector2(-1.34f, 1.6f);
        destinations[1] = new Vector2(1.34f, 1.6f);
        destinations[2] = new Vector2(-3.8f, 1.6f);
        destinations[3] = new Vector2(3.8f, 1.6f);
    }

    private void Update()
    {
        health = gameObject.GetComponent<Enemy>().health;

        if (health <= 800 && allowMinionsSpawn)
        {
            minions = enemySpawner.GetComponent<Spawner>().SpawnMinions();
            allowMinionsSpawn = false;
        }

        if (minions != null)
        {
            for (int i = 0; i < minions.Length; i++)
            {
                // Moving those newly instantitated enemies to their respective fixed positions
                if (minions[i] != null && (Vector2)minions[i].transform.position != destinations[i])
                {
                    minions[i].transform.position = Vector2.MoveTowards(minions[i].transform.position, destinations[i], 15 * Time.deltaTime);
                }
            }
        }

    }



}
